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
        public string connnectionString;
        public bool isRedacting;
        public List<string> comboBoxData = new List<string>();
        public int comboNum;
        public ListOfPartners listOfPartners;
        public AddEditForm()
        {
            InitializeComponent();
        }
        public AddEditForm(int id, string con, bool e, ListOfPartners l)
        {
            InitializeComponent();
            detectedId = id;
            connnectionString = con;
            isRedacting = e;
            listOfPartners = l;
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
                using (SqlConnection connection = new SqlConnection(connnectionString))
                {
                    string sql = "SELECT [Наименование партнера], [Рейтинг], [Юридический адрес партнера], Директор, [Телефон партнера], [Электронная почта партнера], [Тип партнера] FROM Partners INNER JOIN Partners_type ON Partners.id_partners_type = Partners_type.id_partners_type WHERE Partners.id_partners=" + detectedId;

                    adapter = new SqlDataAdapter(sql, connection);
                    ds = new DataSet();
                    adapter.Fill(ds);

                    textBox_name.Text = ds.Tables[0].Rows[0][0].ToString();
                    textBox_rating.Text = ds.Tables[0].Rows[0][1].ToString();
                    textBox_address.Text = ds.Tables[0].Rows[0][2].ToString();
                    textBox_director.Text = ds.Tables[0].Rows[0][3].ToString();
                    textBox_phone.Text = ds.Tables[0].Rows[0][4].ToString();
                    textBox_email.Text = ds.Tables[0].Rows[0][5].ToString();
                    comboBox_partners_type.SelectedItem = ds.Tables[0].Rows[0][6].ToString();
                    comboBox_partners_type.Text = ds.Tables[0].Rows[0][6].ToString();
                }
            }

        }
        private void LoadPartnersData()
        {
            using (SqlConnection connection = new SqlConnection(connnectionString))
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
                using (SqlConnection connection = new SqlConnection(connnectionString))
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
                using (SqlConnection connection = new SqlConnection(connnectionString))
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
