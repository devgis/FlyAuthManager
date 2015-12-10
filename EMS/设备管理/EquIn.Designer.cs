namespace EMS.设备管理
{
    partial class EquIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.equiptypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eMSDS = new EMS.cs.EMSDS();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.equiprlogoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.equiprspecBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.equiptypeTableAdapter = new EMS.cs.EMSDSTableAdapters.equiptypeTableAdapter();
            this.equiprlogoTableAdapter = new EMS.cs.EMSDSTableAdapters.equiprlogoTableAdapter();
            this.equiprspecTableAdapter = new EMS.cs.EMSDSTableAdapters.equiprspecTableAdapter();
            this.departmentTableAdapter = new EMS.cs.EMSDSTableAdapters.departmentTableAdapter();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.usepropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usepropTableAdapter = new EMS.cs.EMSDSTableAdapters.usepropTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.equiptypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMSDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equiprlogoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equiprspecBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usepropBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "设备名称：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 21);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(311, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(143, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "设备类型：";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.equiptypeBindingSource;
            this.comboBox1.DisplayMember = "typename";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(83, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.ValueMember = "typeid";
            // 
            // equiptypeBindingSource
            // 
            this.equiptypeBindingSource.DataMember = "equiptype";
            this.equiptypeBindingSource.DataSource = this.eMSDS;
            // 
            // eMSDS
            // 
            this.eMSDS.DataSetName = "EMSDS";
            this.eMSDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "设备品牌：";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.equiprlogoBindingSource;
            this.comboBox2.DisplayMember = "logoname";
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(237, 36);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(77, 20);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.ValueMember = "logoid";
            // 
            // equiprlogoBindingSource
            // 
            this.equiprlogoBindingSource.DataMember = "equiprlogo";
            this.equiprlogoBindingSource.DataSource = this.eMSDS;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "规格型号：";
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.equiprspecBindingSource;
            this.comboBox3.DisplayMember = "specname";
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(377, 36);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(77, 20);
            this.comboBox3.TabIndex = 9;
            this.comboBox3.ValueMember = "specid";
            // 
            // equiprspecBindingSource
            // 
            this.equiprspecBindingSource.DataMember = "equiprspec";
            this.equiprspecBindingSource.DataSource = this.eMSDS;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "出厂日期：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(76, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 21);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "所属部门：";
            // 
            // comboBox4
            // 
            this.comboBox4.DataSource = this.departmentBindingSource;
            this.comboBox4.DisplayMember = "departname";
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(237, 72);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(92, 20);
            this.comboBox4.TabIndex = 13;
            this.comboBox4.ValueMember = "departid";
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "department";
            this.departmentBindingSource.DataSource = this.eMSDS;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "备注信息：";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 129);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(445, 168);
            this.textBox3.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(309, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "登记日期：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(380, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 19;
            this.label12.Text = "登记日期";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // equiptypeTableAdapter
            // 
            this.equiptypeTableAdapter.ClearBeforeFill = true;
            // 
            // equiprlogoTableAdapter
            // 
            this.equiprlogoTableAdapter.ClearBeforeFill = true;
            // 
            // equiprspecTableAdapter
            // 
            this.equiprspecTableAdapter.ClearBeforeFill = true;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(335, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "使用属性：";
            // 
            // comboBox5
            // 
            this.comboBox5.DataSource = this.usepropBindingSource;
            this.comboBox5.DisplayMember = "propname";
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(394, 71);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(63, 20);
            this.comboBox5.TabIndex = 23;
            this.comboBox5.ValueMember = "propid";
            // 
            // usepropBindingSource
            // 
            this.usepropBindingSource.DataMember = "useprop";
            this.usepropBindingSource.DataSource = this.eMSDS;
            // 
            // usepropTableAdapter
            // 
            this.usepropTableAdapter.ClearBeforeFill = true;
            // 
            // EquIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 340);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "EquIn";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备信息录入";
            this.Load += new System.EventHandler(this.EquIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.equiptypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMSDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equiprlogoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equiprspecBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usepropBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private EMS.cs.EMSDS eMSDS;
        private System.Windows.Forms.BindingSource equiptypeBindingSource;
        private EMS.cs.EMSDSTableAdapters.equiptypeTableAdapter equiptypeTableAdapter;
        private System.Windows.Forms.BindingSource equiprlogoBindingSource;
        private EMS.cs.EMSDSTableAdapters.equiprlogoTableAdapter equiprlogoTableAdapter;
        private System.Windows.Forms.BindingSource equiprspecBindingSource;
        private EMS.cs.EMSDSTableAdapters.equiprspecTableAdapter equiprspecTableAdapter;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private EMS.cs.EMSDSTableAdapters.departmentTableAdapter departmentTableAdapter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.BindingSource usepropBindingSource;
        private EMS.cs.EMSDSTableAdapters.usepropTableAdapter usepropTableAdapter;
    }
}