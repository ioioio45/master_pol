using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace master_pol_enn
{
    public partial class HistoryForm : Form
    {
        int id;
        string connectionString;
        SqlDataAdapter adapter;
        DataSet ds;
        public HistoryForm()
        {
            InitializeComponent();
        }
        public HistoryForm(int id, string connectionString, ApplicationsForm applicationsForm)
        {
            InitializeComponent();
            this.id = id;
            this.connectionString = connectionString;
            this.applicationsForm = applicationsForm;
        }
        private void LoadHistory()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "SELECT Products.[Наименование продукции], Partner_products.[Количество продукции], Partner_products.[Дата продажи]\r\nFROM Products INNER JOIN  Partner_products ON Products.id_products = Partner_products.id_products WHERE id_partners=" + id;
                    adapter = new SqlDataAdapter(sql, conn);
                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch(SqlException ex){
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            LoadHistory();
        }
    }
}
