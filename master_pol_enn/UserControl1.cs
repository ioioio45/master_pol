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
    public partial class UserControl1 : UserControl
    {
        public List<string> partnerDetails { get; set; } 
        public UserControl1()
        {
            InitializeComponent();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            type_label.Text = partnerDetails[0];
            partner_label.Text = partnerDetails[1];
            director_label.Text = partnerDetails[2];
            phone_label.Text = "+7 "+partnerDetails[3];
            rating_label.Text = "Рейтинг: "+partnerDetails[4];
            discount_label.Text = partnerDetails[5]+'%';
        }

        private void UserControl1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void UserControl1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void UserControl1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#67BA80");
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(628,130);
        }
    }
}
