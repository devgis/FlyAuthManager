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

namespace EMS.租赁管理
{
    public partial class EquLog : Form
    {
        public EquLog()
        {
            InitializeComponent();
        }

        private void EquLog_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.lendlog”中。您可以根据需要移动或移除它。
            this.lendlogTableAdapter.Fill(this.eMSDS.lendlog);
            // TODO: 这行代码将数据加载到表“eMSDS.lendlog”中。您可以根据需要移动或移除它。
            this.lendlogTableAdapter.Fill(this.eMSDS.lendlog);
            // TODO: 这行代码将数据加载到表“eMSDS.lendlog”中。您可以根据需要移动或移除它。
            this.lendlogTableAdapter.Fill(this.eMSDS.lendlog);
            // TODO: 这行代码将数据加载到表“eMSDS.lendlog”中。您可以根据需要移动或移除它。
            this.lendlogTableAdapter.Fill(this.eMSDS.lendlog);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sn = textBox1.Text.Trim();
            string lendstarttime = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string lendendtime = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            string selstr = string.Format("SELECT lendlog.logid, lendlog.sn, lendlog.lenddate, lendlog.returndate,person.personname, [user].username AS lendusername,user_1.username AS returnuser, lendlog.other FROM lendlog INNER JOIN [user] ON lendlog.lendUserid = [user].userid INNER JOIN [user] user_1 ON lendlog.returnUserid = user_1.userid INNER JOIN person ON lendlog.personid = person.personid WHERE (sn LIKE '%{0}%') AND(lenddate between '{1}' and '{2}')", sn, lendstarttime, lendendtime);
            DataSet ds = new DataSet();
            exsql eq = new exsql();
            ds = eq.excuterdataset(selstr);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].HeaderText = "序号";
            dataGridView1.Columns[1].HeaderText = "设备编号";
            dataGridView1.Columns[2].HeaderText = "租出日期";
            dataGridView1.Columns[3].HeaderText = "归还日期";
            dataGridView1.Columns[4].HeaderText = "租借人";
            dataGridView1.Columns[5].HeaderText = "租出管理员";
            dataGridView1.Columns[6].HeaderText = "收还管理员";
            dataGridView1.Columns[7].HeaderText = "备注信息";
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
