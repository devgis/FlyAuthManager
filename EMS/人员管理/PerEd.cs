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

namespace EMS.人员管理
{
    public partial class PerEd : Form
    {
        public string username;
        public int userid;
        exsql eq = new exsql();
        public PerEd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string upstr = string.Format("UPDATE equipment SET equipname = '{0}',typeid={1},logoid={2},specid={3},proddate='{4}',departid={5},other='{6}' WHERE (sn = '001')", textBox2.Text.Trim(), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox3.SelectedValue), dateTimePicker1.Value.ToString("yyyyMMdd"), Convert.ToInt32(comboBox4.SelectedValue), textBox3.Text);
            //eq.excutesql(upstr);
            MessageBox.Show("更新成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PerEd_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.eMSDS.department);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox4.Text.Trim());
            }
            catch (FormatException)
            {
                //MessageBox.Show("请输入数字！");
                textBox4.Text = "";
            }
            string NO = textBox4.Text.Trim();
            string selstr = string.Format("select personname,departid,[position],other from person where [NO]='{0}'",NO);
            SqlDataReader reader = eq.excutereader(selstr);
            reader.Read();
            try
            {
                Convert.ToString(reader[0]);
                //设置有效
                textBox2.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;

                //赋值
                textBox2.Text  = reader[0].ToString();
                comboBox1.SelectedValue = Convert.ToInt32(reader[1].ToString().Trim()); 
                //MessageBox.Show(reader[2].ToString());
                comboBox2.Text = reader[2].ToString();
                textBox3.Text = reader[3].ToString();
            }
            catch (InvalidOperationException)
            {
                //数据为空时不做任何处理
                textBox2.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = false;
            }
        }
    }
}