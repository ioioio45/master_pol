namespace master_pol_enn
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.master_pol_ennDataSet = new master_pol_enn.master_pol_ennDataSet();
            this.masterpolennDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materialtypeimportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.material_type_importTableAdapter = new master_pol_enn.master_pol_ennDataSetTableAdapters.Material_type_importTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_partners_list = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.master_pol_ennDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterpolennDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialtypeimportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // master_pol_ennDataSet
            // 
            this.master_pol_ennDataSet.DataSetName = "master_pol_ennDataSet";
            this.master_pol_ennDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // masterpolennDataSetBindingSource
            // 
            this.masterpolennDataSetBindingSource.DataSource = this.master_pol_ennDataSet;
            this.masterpolennDataSetBindingSource.Position = 0;
            // 
            // materialtypeimportBindingSource
            // 
            this.materialtypeimportBindingSource.DataMember = "Material_type_import";
            this.materialtypeimportBindingSource.DataSource = this.master_pol_ennDataSet;
            // 
            // material_type_importTableAdapter
            // 
            this.material_type_importTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(49, 28);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button_partners_list);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 450);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Добавить/Редактировать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_partners_list
            // 
            this.button_partners_list.Location = new System.Drawing.Point(39, 104);
            this.button_partners_list.Name = "button_partners_list";
            this.button_partners_list.Size = new System.Drawing.Size(151, 32);
            this.button_partners_list.TabIndex = 0;
            this.button_partners_list.Text = "Список Партнеров";
            this.button_partners_list.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(225, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 450);
            this.panel2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.master_pol_ennDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterpolennDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialtypeimportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource masterpolennDataSetBindingSource;
        private master_pol_ennDataSet master_pol_ennDataSet;
        private System.Windows.Forms.BindingSource materialtypeimportBindingSource;
        private master_pol_ennDataSetTableAdapters.Material_type_importTableAdapter material_type_importTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_partners_list;
    }
}

