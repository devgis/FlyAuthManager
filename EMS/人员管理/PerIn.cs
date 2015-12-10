using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using flylib;

namespace EMS.人员管理
{
    public partial class PerIn : Form
    {
        public string username;
        public int userid;
        public PerIn()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("工号或姓名不能为空！");
            }
            else
            {
                string NO =textBox1.Text.Trim();
                string personname = textBox2.Text.Trim();
                int departid = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                string position = comboBox2.Text.Trim();
                string other = textBox3.Text;

                string instr = string.Format("insert into person([NO],personname,departid,[position],other)values('{0}','{1}',{2},'{3}','{4}')", NO, personname, departid, position, other);
                exsql eq = new exsql();
                eq.excutesql(instr);
            }
            MessageBox.Show("插入成功！");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PerIn_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.eMSDS.department);

        }
    }
}
