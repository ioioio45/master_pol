using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace master_pol_enn
{
    public partial class Form1 : Form
    {
        
        string connectionString = "Data Source=NURGUN\\EWYANG;Initial Catalog=master_pol_enn;Integrated Security=True";
        PartnersForm partnersForm;
        ListOfPartners listOfPartners;
        ApplicationsForm applicationsForm;
        MaterialCountForm materialCountForm;
        public Form1()
        {
            InitializeComponent();
            partnersForm = new PartnersForm(connectionString);
            listOfPartners = new ListOfPartners(connectionString);
            applicationsForm = new ApplicationsForm(connectionString);
            materialCountForm = new MaterialCountForm(connectionString);
            Font newFont = new Font("Segoe UI", 8);
            ChangeFontForAllControls(this, newFont);
            panel1.BackColor = ColorTranslator.FromHtml("#F4E8D3");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            
            partnersForm.TopLevel = false;
            partnersForm.FormBorderStyle = FormBorderStyle.None;
            partnersForm.Show();
            panel2.Controls.Add(partnersForm);
            panel1.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            panel2.BackColor = Color.White;
        }
        private void button_partners_list_Click(object sender, EventArgs e)
        {
            listOfPartners.Hide();
            applicationsForm.Hide();
            materialCountForm.Hide();

            partnersForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            partnersForm.Hide();
            applicationsForm.Hide();
            materialCountForm.Hide();

            listOfPartners.TopLevel = false;
            listOfPartners.FormBorderStyle = FormBorderStyle.None;
            listOfPartners.Show();
            panel2.Controls.Add(listOfPartners);
            panel1.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            panel2.BackColor = Color.White;
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            listOfPartners.Hide();
            partnersForm.Hide();
            materialCountForm.Hide();

            applicationsForm.TopLevel = false;
            applicationsForm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(applicationsForm);
            applicationsForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listOfPartners.Hide();
            partnersForm.Hide();
            applicationsForm.Hide();

            materialCountForm.TopLevel = false;
            materialCountForm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(materialCountForm);
            materialCountForm.Show();
        }
        private void ChangeFontForAllControls(Control control, Font newFont)
        {
            control.Font = newFont;
            foreach (Control childControl in control.Controls)
            {
                ChangeFontForAllControls(childControl, newFont);
            }
        }
    }
}
