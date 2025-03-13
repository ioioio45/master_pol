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
    public partial class HistoryForm : Form
    {
        int id;
        string connectionString;
        ApplicationsForm applicationsForm;
        SqlDataAdapter adapter;
        DataSet ds;
        public HistoryForm()
        {
            InitializeComponent();
        }
        public HistoryForm(int detectedId, string c, ApplicationsForm a)
        {
            InitializeComponent();
            id = detectedId;
            connectionString = c;
            applicationsForm = a;
        }
        private void LoadHistory()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT Products.[Наименование продукции], Partner_products.[Количество продукции], Partner_products.[Дата продажи]\r\nFROM Products INNER JOIN  Partner_products ON Products.id_products = Partner_products.id_products WHERE id_partners="+id;
                adapter = new SqlDataAdapter(sql, conn);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
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
