using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using flylib;

namespace EMS.报表管理
{
    public partial class 清查明细表 : Form
    {
        string selstr;
        int departid;
        public 清查明细表()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 清查明细表_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.eMSDS.department);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            departid = Convert.ToInt32(comboBox1.SelectedValue);
            if (comboBox1.Text == "*")
            {
                selstr = "SELECT equipname, COUNT(equipname) AS Expr1 FROM equipment GROUP BY equipname";
            }
            else
            {
                
                if (departid == 0)
                {
                    MessageBox.Show("没有该部门，要查找所有部门，请输入\"*\"");
                }
                else
                {
                    selstr = string.Format("SELECT equipname, COUNT(equipname) AS Expr1 FROM equipment WHERE departid = {0} GROUP BY equipname", departid);
                }
            }

            flylib.exsql eq = new exsql();
            DataSet ds = new DataSet();
            ds = eq.excuterdataset(selstr);

            报表管理.rpt.清查明细表 rpt = new EMS.报表管理.rpt.清查明细表();
            rpt.SetDataSource (ds.Tables[0]);
            TextObject depart = rpt.ReportDefinition.ReportObjects["Text18"] as TextObject;
            depart.Text = comboBox1.Text;
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
