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
        
        string connectionString = "Data Source=DESKTOP-DE\\LAB7PC7;Initial Catalog=master_pol_enn;Integrated Security=True";
        public ListOfPartners()
        {
            InitializeComponent();
        }

        private void ListOfPartners_Load(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT [Наименование партнера], Partners_type.[Тип партнера], Рейтинг, [Юридический адрес партнера], Директор, [Телефон партнера], [Электронная почта партнера] FROM Partners INNER JOIN Partners_type ON Partners.id_partners_type = Partners_type.id_partners_type";
                adapter = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> myList = new List<string>();
            if (dataGridView1.SelectedRows.Count ==1)
            {
                AddEditForm addEditForm = new AddEditForm();
                addEditForm.Show();
                for(int i = 0;i<7;i++)
                {
                    myList.Add("GGGGG");
                }
                addEditForm.list = myList;
            }
        }
    }
}
