using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace master_pol_enn
{
    
    public partial class AddEditForm : Form
    {
        public List<string> list { get; set; }
        public AddEditForm()
        {
            InitializeComponent();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            textBox_name.Text = list[0].ToString();
            textBox_rating.Text = list[2].ToString();
            textBox_address.Text = list[3].ToString();
            textBox_director.Text = list[4].ToString();
            textBox_phone.Text = list[5].ToString();
            textBox_email.Text = list[6].ToString();


        }
    }
}
