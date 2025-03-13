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
    public partial class PartnersForm : Form
    {
        SqlDataAdapter adapter;
        DataSet ds, localDs;
        StringBuilder sb = new StringBuilder();
        List<string> list = new List<string>();
        string connectionString;
        int pointY = 50;
        public PartnersForm()
        {
            InitializeComponent();
        }
        public PartnersForm(string cS)
        {
            InitializeComponent();
            connectionString = cS;
        }
        private void PartnersForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;

            string selectString = "SELECT [Тип партнера], [Наименование партнера], Директор, [Телефон партнера], Рейтинг FROM Partners INNER JOIN Partners_type ON Partners.[id_partners_type] = Partners_type.id_partners_type;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(selectString, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                ds.Tables[0].Columns.Add("Скидка", typeof(int));
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    row["Скидка"] = GetDiscount(GetTotalSales(row["Наименование партнера"].ToString()));
                }
                RenderDiscounts(ds);
            }
        }
        private int GetTotalSales(string partner)
        {
            int totalSales = 0;
            string selectString = "SELECT [Наименование партнера], SUM([Количество продукции]) FROM Partners INNER JOIN Partner_products ON Partners.id_partners = Partner_products.id_partners GROUP BY [Наименование партнера];";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                adapter = new SqlDataAdapter(selectString, connection);
                localDs = new DataSet();
                adapter.Fill(localDs);
                foreach (DataRow row in localDs.Tables[0].Rows)
                {
                    if (row[0].ToString() == partner)
                    {
                        totalSales = int.Parse(row[1].ToString());
                        break;
                    }
                }

            }
            return totalSales;
        }
        private int GetDiscount(int totalSales)
        {
            int discount = 0;
            if (totalSales < 10000)
            {
                discount = 0;
            }
            else if (totalSales >= 10000 && totalSales < 50000)
            {
                discount = 5;
            }
            else if (totalSales >= 50000 && totalSales < 300000)
            {
                discount = 10;
            }
            else if (totalSales >= 300000)
            {
                discount = 15;
            }
            return discount;
        }
        private void RenderDiscounts(DataSet ds)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list = new List<string>();
                UserControl1 userControl1 = new UserControl1();
                userControl1.Location = new System.Drawing.Point(0, pointY);
                userControl1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
                userControl1.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
                pointY += userControl1.Size.Height;
                foreach (Object col in row.ItemArray)
                {
                    list.Add(col.ToString());
                }
                userControl1.partnerDetails = list;
                this.Controls.Add(userControl1);
            }
        }
    }
}
