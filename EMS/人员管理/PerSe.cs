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
    public partial class PerSe : Form
    {
        DataSet ds = new DataSet();
        exsql eq = new exsql();
        public PerSe()
        {
            InitializeComponent();
        }

        private void PerSe_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.eMSDS.department);
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            allload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NO = textBox1.Text;
            string personname = textBox2.Text;
            int departid = Convert.ToInt32(comboBox1.SelectedValue);
            string position = comboBox2.Text;

            string selstr = string.Format("SELECT dbo.person.personid, dbo.person.[NO], dbo.person.personname,dbo.department.departname, dbo.person.[position], dbo.person.other FROM dbo.person INNER JOIN dbo.department ON dbo.person.departid = dbo.department.departid where(dbo.person.[NO] like '%{0}%' AND dbo.person.personname like '%{1}%' AND dbo.person.departid={2} and dbo.person.[position]='{3}')", NO, personname, departid, position);
            ds = eq.excuterdataset(selstr);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void allload()
        {
            string selstr = "SELECT dbo.person.personid, dbo.person.[NO], dbo.person.personname,dbo.department.departname, dbo.person.[position], dbo.person.other FROM dbo.person INNER JOIN dbo.department ON dbo.person.departid = dbo.department.departid";
            ds = eq.excuterdataset(selstr);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "人员编号";
            dataGridView1.Columns[1].HeaderText = "工号"; 
            dataGridView1.Columns[2].HeaderText = "姓名";
            dataGridView1.Columns[3].HeaderText = "部门";
            dataGridView1.Columns[4].HeaderText = "职位";
            dataGridView1.Columns[5].HeaderText = "备注信息";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
