using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using flylib;

namespace EMS.设备管理
{
    public partial class EquEd : Form
    {
        public string username;
        public int userid;
        exsql eq = new exsql();
        public EquEd()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox1.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入数字！");
                textBox1.Text = "";
            }
            string sn = textBox1.Text.Trim();
            string selstr = string.Format("select equipname,typeid,logoid,specid,proddate,departid,other from equipment where sn='{0}'", sn);
            SqlDataReader reader = eq.excutereader(selstr);
            reader.Read();
            try
            {
                Convert.ToString(reader[0]);
                //设置有效
                textBox2.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                dateTimePicker1.Enabled = true;
                comboBox4.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;

                //赋值
                textBox2.Text = reader[0].ToString();
                comboBox1.SelectedValue = Convert.ToInt32(reader[1]);
                comboBox2.SelectedValue = Convert.ToInt32(reader[2]);
                comboBox3.SelectedValue = Convert.ToInt32(reader[3]);
                dateTimePicker1.Value = Convert.ToDateTime(reader[4]);
                comboBox4.SelectedValue = Convert.ToInt32(reader[5]);
                textBox3.Text = reader[6].ToString();
            }
            catch (InvalidOperationException)
            {
                //数据为空时不做任何处理
                textBox2.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox4.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void EquEd_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.eMSDS.department);
            // TODO: 这行代码将数据加载到表“eMSDS.equiprspec”中。您可以根据需要移动或移除它。
            this.equiprspecTableAdapter.Fill(this.eMSDS.equiprspec);
            // TODO: 这行代码将数据加载到表“eMSDS.equiprlogo”中。您可以根据需要移动或移除它。
            this.equiprlogoTableAdapter.Fill(this.eMSDS.equiprlogo);
            // TODO: 这行代码将数据加载到表“eMSDS.equiptype”中。您可以根据需要移动或移除它。
            this.equiptypeTableAdapter.Fill(this.eMSDS.equiptype);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string upstr = string.Format("UPDATE equipment SET equipname = '{0}',typeid={1},logoid={2},specid={3},proddate='{4}',departid={5},other='{6}' WHERE (sn = '001')", textBox2.Text.Trim(), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue), dateTimePicker1.Value.ToString("yyyyMMdd"), Convert.ToInt32(comboBox4.SelectedValue), textBox3.Text);
            eq.excutesql(upstr);
            MessageBox.Show("更新成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
