namespace master_pol_enn
{
    partial class UserControl1
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.type_label = new System.Windows.Forms.Label();
            this.partner_label = new System.Windows.Forms.Label();
            this.discount_label = new System.Windows.Forms.Label();
            this.director_label = new System.Windows.Forms.Label();
            this.phone_label = new System.Windows.Forms.Label();
            this.rating_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // type_label
            // 
            this.type_label.AutoSize = true;
            this.type_label.Location = new System.Drawing.Point(27, 13);
            this.type_label.Name = "type_label";
            this.type_label.Size = new System.Drawing.Size(31, 13);
            this.type_label.TabIndex = 0;
            this.type_label.Text = "Type";
            // 
            // partner_label
            // 
            this.partner_label.AutoSize = true;
            this.partner_label.Location = new System.Drawing.Point(88, 13);
            this.partner_label.Name = "partner_label";
            this.partner_label.Size = new System.Drawing.Size(72, 13);
            this.partner_label.TabIndex = 1;
            this.partner_label.Text = "Partner Name";
            // 
            // discount_label
            // 
            this.discount_label.AutoSize = true;
            this.discount_label.Location = new System.Drawing.Point(505, 13);
            this.discount_label.Name = "discount_label";
            this.discount_label.Size = new System.Drawing.Size(49, 13);
            this.discount_label.TabIndex = 2;
            this.discount_label.Text = "Discount";
            // 
            // director_label
            // 
            this.director_label.AutoSize = true;
            this.director_label.Location = new System.Drawing.Point(27, 38);
            this.director_label.Name = "director_label";
            this.director_label.Size = new System.Drawing.Size(44, 13);
            this.director_label.TabIndex = 3;
            this.director_label.Text = "Director";
            // 
            // phone_label
            // 
            this.phone_label.AutoSize = true;
            this.phone_label.Location = new System.Drawing.Point(27, 65);
            this.phone_label.Name = "phone_label";
            this.phone_label.Size = new System.Drawing.Size(78, 13);
            this.phone_label.TabIndex = 4;
            this.phone_label.Text = "Phone Number";
            // 
            // rating_label
            // 
            this.rating_label.AutoSize = true;
            this.rating_label.Location = new System.Drawing.Point(27, 87);
            this.rating_label.Name = "rating_label";
            this.rating_label.Size = new System.Drawing.Size(54, 13);
            this.rating_label.TabIndex = 5;
            this.rating_label.Text = "Рейтинг: ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.discount_label);
            this.panel1.Controls.Add(this.rating_label);
            this.panel1.Controls.Add(this.partner_label);
            this.panel1.Controls.Add(this.type_label);
            this.panel1.Controls.Add(this.phone_label);
            this.panel1.Controls.Add(this.director_label);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 110);
            this.panel1.TabIndex = 6;
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "UserControl1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(628, 130);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.MouseEnter += new System.EventHandler(this.UserControl1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UserControl1_MouseLeave);
            this.MouseHover += new System.EventHandler(this.UserControl1_MouseHover);
            this.Resize += new System.EventHandler(this.UserControl1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label type_label;
        private System.Windows.Forms.Label partner_label;
        private System.Windows.Forms.Label discount_label;
        private System.Windows.Forms.Label director_label;
        private System.Windows.Forms.Label phone_label;
        private System.Windows.Forms.Label rating_label;
        private System.Windows.Forms.Panel panel1;
    }
}
