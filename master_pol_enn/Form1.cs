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
        PartnersForm partnersForm = new PartnersForm();
        ListOfPartners listOfPartners = new ListOfPartners();
        public Form1()
        {
            InitializeComponent();

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

        private void button2_Click(object sender, EventArgs e)
        {
            partnersForm.Hide();
            listOfPartners.TopLevel = false;
            listOfPartners.FormBorderStyle = FormBorderStyle.None;
            listOfPartners.Show();
            panel2.Controls.Add(listOfPartners);
            panel1.BackColor = ColorTranslator.FromHtml("#F4E8D3");
            panel2.BackColor = Color.White;
        }
    }
}
