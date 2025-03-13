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
    public partial class ApplicationsForm : Form
    {
        SqlDataAdapter adapter;
        DataSet ds;
        string connectionString;
        public ApplicationsForm()
        {
            InitializeComponent();
        }
        public ApplicationsForm(string c)
        {
            InitializeComponent();
            connectionString = c;
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

        private void ApplicationsForm_Load(object sender, EventArgs e)
        {
            LoadPartners();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                HistoryForm historyForm = new HistoryForm(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()), connectionString, this);
                historyForm.Show();
            }
        }
    }
}
