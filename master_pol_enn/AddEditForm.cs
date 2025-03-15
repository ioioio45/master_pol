using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace master_pol_enn
{

    public partial class AddEditForm : Form
    {
        public SqlDataAdapter adapter;
        public DataSet ds;
        public int detectedId = 0;
        public string connectionString;
        public bool isRedacting;
        public List<string> comboBoxData = new List<string>();
        public int comboNum;
        public ListOfPartners listOfPartners;
        public AddEditForm()
        {
            InitializeComponent();
        }
        public AddEditForm(int detectedId, string connectionString, bool isRedacting, ListOfPartners listOfPartners)
        {
            InitializeComponent();
            this.detectedId = detectedId;
            this.connectionString = connectionString;
            this.isRedacting = isRedacting;
            this.listOfPartners = listOfPartners;
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            LoadPartnersData();
            if (detectedId != 0)
            {
                if (isRedacting)
                {
                    button1.Text = "Изменить";
                }
                else
                {
                    button1.Text = "Добавить";
                }
                try
                {

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string sql = "SELECT [Наименование партнера], [Рейтинг], [Юридический адрес партнера], Директор, [Телефон партнера], [Электронная почта партнера], [Тип партнера] FROM Partners INNER JOIN Partners_type ON Partners.id_partners_type = Partners_type.id_partners_type WHERE Partners.id_partners=" + detectedId;
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        connection.Open();

                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            if(dataReader.Read())
                            {
                                textBox_name.Text = dataReader["Наименование партнера"].ToString();
                                textBox_rating.Text = dataReader["Рейтинг"].ToString();
                                textBox_address.Text = dataReader["Юридический адрес партнера"].ToString();
                                textBox_director.Text = dataReader["Директор"].ToString();
                                textBox_phone.Text = dataReader["Телефон партнера"].ToString();
                                textBox_email.Text = dataReader["Электронная почта партнера"].ToString();
                                comboBox_partners_type.SelectedItem = dataReader["Тип партнера"].ToString();
                                comboBox_partners_type.Text = dataReader["Тип партнера"].ToString();
                            }
                        }
                        connection.Close();
                    }
                }
                catch(SqlException ex) {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        private void LoadPartnersData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlTypes = "SELECT [Тип партнера] FROM Partners_type";
                adapter = new SqlDataAdapter(sqlTypes, connection);
                ds = new DataSet();
                adapter.Fill(ds, "PartnersType");

                foreach (DataRow row in ds.Tables["PartnersType"].Rows)
                {
                    comboBoxData.Add(row[0].ToString());
                }
                comboBox_partners_type.DataSource = comboBoxData;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(textBox_rating.Text, out int r))
            {
                r = -1;
            }
            
            if (!ValidateData(textBox_name.Text, comboBox_partners_type.Text, r,textBox_address.Text, textBox_director.Text, textBox_phone.Text, textBox_email.Text))
            {
                SqlInsert();
            }
            
        }
        private bool ValidateData(string name, string type, int rating, string address, string FIO, string phone, string email)
        {
            bool found = false;
            string alertString="";
            if(name=="")
            {
                alertString += "Некорректное наименование\n";
                found = true;
            }
            if(type == "")
            {
                alertString += "Некорректный тип\n";
                found = true;
            }
            if((rating<0 || rating>10))
            {
                alertString += "Некорректный рейтинг\n";
                found = true;
            }
            if(address == "")
            {
                alertString += "Некорректный адрес\n";
                found = true;
            }
            if (FIO == "")
            {
                alertString += "Некорректный адрес\n";
                found = true;
            }
            if (phone == "")
            {
                alertString += "Некорректный телефон\n";
                found = true;
            }
            if (email == "")
            {
                alertString += "Некорректная почта\n";
                found = true;
            }
            if(found)
                MessageBox.Show(alertString);
            return found;
        }
        private void SqlInsert()
        {
            switch (comboBox_partners_type.Text)
            {
                case "ЗАО": comboNum = 1; break;
                case "ООО": comboNum = 2; break;
                case "ПАО": comboNum = 3; break;
                case "ОАО": comboNum = 4; break;
            }
            if (isRedacting)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Partners SET [Наименование партнера]='" + textBox_name.Text + "', [Рейтинг]=" + textBox_rating.Text + ", [Юридический адрес партнера]='" + textBox_address.Text + "', Директор='" + textBox_director.Text + "', [Телефон партнера]='" + textBox_phone.Text + "', [Электронная почта партнера]='" + textBox_email.Text + "', id_partners_type='" + comboNum + "' WHERE id_partners=" + detectedId, connection);
                    sqlCommand.ExecuteNonQuery();
                    listOfPartners.LoadPartners();
                    connection.Close();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Partners (id_partners_type, [Наименование партнера],Директор,[Электронная почта партнера],[Телефон партнера],[Юридический адрес партнера],Рейтинг) VALUES (" + comboNum + ",'" + textBox_name.Text + "','" + textBox_director.Text + "','" + textBox_email.Text + "','" + textBox_phone.Text + "','" + textBox_address.Text + "','" + textBox_rating.Text + "')", connection);
                    sqlCommand.ExecuteNonQuery();
                    listOfPartners.LoadPartners();
                    connection.Close();
                }
            }
        }
    }
}
