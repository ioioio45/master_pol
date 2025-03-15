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
    public partial class MaterialCountForm : Form
    {
        private string connectionString;
        private SqlDataAdapter adapter;
        private DataSet ds;
        private List<string> comboBoxData = new List<string>();
        private float coef, broke;
        public MaterialCountForm()
        {
            InitializeComponent();
        }
        public MaterialCountForm(string c)
        {
            InitializeComponent();
            connectionString = c;
        }
        private void LoadComboBoxes()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string materialTypeComboSql = "SELECT [Наименование продукции] FROM Products";
                    adapter = new SqlDataAdapter(materialTypeComboSql, sqlConnection);
                    ds = new DataSet();
                    adapter.Fill(ds);
                }
                foreach(DataRow row in ds.Tables[0].Rows) {
                    comboBoxData.Add(row[0].ToString());
                }
                comboBox1.DataSource = comboBoxData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public int CalculateRequiredMaterial(int count, float coefficient, float brokeCoefficient)
        {
            if (count < 0 || coefficient <0 || brokeCoefficient < 0)
            {
                return -1;
            }

            double baseMaterial = count / coefficient;

            double totalMaterial = baseMaterial * (1 + brokeCoefficient / 100.0);

            return (int)Math.Round(totalMaterial);
        }

        private void MaterialCountForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    string getProductDataSql = "SELECT [Наименование продукции],[Коэффициент типа продукции],[Процент брака материала ] FROM (Products INNER JOIN [Product_type] ON Products.id_product_type = Product_type.id_product_type) INNER JOIN Material_type ON Products.id_material_type = Material_type.id_material_type;";
                    adapter = new SqlDataAdapter(getProductDataSql, sqlConnection);
                    ds = new DataSet();
                    adapter.Fill(ds);
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        if (row[0].ToString() == comboBox1.SelectedItem.ToString())
                        {
                            coef = float.Parse(row[1].ToString());
                            broke = float.Parse(row[2].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(int.TryParse(textBox1.Text, out int r))
                MessageBox.Show("Необходимо материала: "+CalculateRequiredMaterial(r, coef, broke).ToString());
        }
    }
}
