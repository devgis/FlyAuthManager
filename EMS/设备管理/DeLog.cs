using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using flylib;

namespace EMS.设备管理
{
    public partial class DeLog : Form
    {
        public DeLog()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeLog_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.equiplog”中。您可以根据需要移动或移除它。
            this.equiplogTableAdapter.Fill(this.eMSDS.equiplog);
            // TODO: 这行代码将数据加载到表“eMSDS.equiplog”中。您可以-根据需要移动或移除它。
            this.equiplogTableAdapter.Fill(this.eMSDS.equiplog);
            // TODO: 这行代码将数据加载到表“eMSDS.equiplog”中。您可以根据需要移动或移除它。
            this.equiplogTableAdapter.Fill(this.eMSDS.equiplog);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string starttime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string endtime = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string selstr = string.Format("SELECT equiplog.logtid, equiplog.sn, person.personname, [user].username,equiplog.logtype, equiplog.optime, equiplog.other FROM equiplog INNER JOIN person ON equiplog.personid = person.personid CROSS JOIN [user] WHERE (sn LIKE '%{0}%') AND (logtype LIKE '%{1}%') AND(optime between '{2}' and '{3}')", textBox1.Text, comboBox1.Text, starttime, endtime);
            DataSet ds = new DataSet();
            exsql eq = new exsql();
            ds = eq.excuterdataset(selstr);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "序号";
            dataGridView1.Columns[1].HeaderText = "设备编号";
            dataGridView1.Columns[2].HeaderText = "职员";
            dataGridView1.Columns[3].HeaderText = "管理员";
            dataGridView1.Columns[4].HeaderText = "处理类型";
            dataGridView1.Columns[5].HeaderText = "操作时间";
            dataGridView1.Columns[6].HeaderText = "备注信息";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDecimal(textBox1.Text);
            }
            catch (FormatException)
            {
                textBox1.Text = "";
            }
        }
    }
}
