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
    public partial class ListOfPartners : Form
    {
        SqlDataAdapter adapter;
        DataSet ds;

        string connectionString;
        public ListOfPartners()
        {
            InitializeComponent();
        }
        public ListOfPartners(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }
        private void ListOfPartners_Load(object sender, EventArgs e)
        {
            LoadPartners();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                AddEditForm addEditForm = new AddEditForm(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), connectionString, true, this);
                addEditForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string sql = "DELETE FROM Partners WHERE id_partners=" + dataGridView1.SelectedRows[0].Cells[0].Value;
                        conn.Open();
                        SqlCommand sqlCommand = new SqlCommand(sql, conn);
                        sqlCommand.ExecuteNonQuery();
                        conn.Close();
                        LoadPartners();
                    }
                } catch(SqlException ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm(0, connectionString, false, this);
            addEditForm.Show();
        }
        public void LoadPartners()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT id_partners,[Наименование партнера], Partners_type.[Тип партнера], Рейтинг, [Юридический адрес партнера], Директор, [Телефон партнера], [Электронная почта партнера] FROM Partners INNER JOIN Partners_type ON Partners.id_partners_type = Partners_type.id_partners_type";
                adapter = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
