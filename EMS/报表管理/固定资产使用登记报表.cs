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
    public partial class 固定资产使用登记报表 : Form
    {
        string selstr;
        int typeid,departid;
        public 固定资产使用登记报表()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void 固定资产使用登记报表_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.eMSDS.department);
            // TODO: 这行代码将数据加载到表“eMSDS.equiptype”中。您可以根据需要移动或移除它。
            this.equiptypeTableAdapter.Fill(this.eMSDS.equiptype);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            typeid = Convert.ToInt32(comboBox1.SelectedValue);
            departid = Convert.ToInt32(comboBox2.SelectedValue);
            if (comboBox1.Text == "*")
            {
                if (comboBox2.Text == "*")
                {
                    selstr = "SELECT equipment.sn, equipment.equipname, equiprlogo.logoname,equiprspec.specname, equipment.inputdate, equipment.proddate, equipment.state,equipment.inputer, equipment.other FROM equipment INNER JOIN equiprlogo ON equipment.logoid = equiprlogo.logoid INNER JOIN equiprspec ON equipment.specid = equiprspec.specid";
                }
                else {
                    if (departid == 0)
                    {
                        MessageBox.Show("没有该该部门，要查找所有部门，请输入\"*\"");
                    }
                    else
                    {
                        selstr = string.Format("SELECT equipment.sn, equipment.equipname, equiprlogo.logoname,equiprspec.specname, equipment.inputdate, equipment.proddate, equipment.state,equipment.inputer, equipment.other FROM equipment INNER JOIN equiprlogo ON equipment.logoid = equiprlogo.logoid INNER JOIN equiprspec ON equipment.specid = equiprspec.specid where equipment.departid={0}", departid);
                    }  
                }
                
            }
            else
            {

                if (typeid == 0)
                {
                    MessageBox.Show("没有该该类别，要查找所有类别，请输入\"*\"");
                }
                else
                {
                    if (comboBox2.Text == "*")
                    {
                        selstr = string.Format("SELECT equipment.sn, equipment.equipname, equiprlogo.logoname,equiprspec.specname, equipment.inputdate, equipment.proddate, equipment.state,equipment.inputer, equipment.other FROM equipment INNER JOIN equiprlogo ON equipment.logoid = equiprlogo.logoid INNER JOIN equiprspec ON equipment.specid = equiprspec.specid where equipment.typeid={0}", typeid);
                    }
                    else
                    {
                        if (departid == 0)
                        {
                            MessageBox.Show("没有该该部门，要查找所有部门，请输入\"*\"");
                        }
                        else
                        {
                            selstr = string.Format("SELECT equipment.sn, equipment.equipname, equiprlogo.logoname,equiprspec.specname, equipment.inputdate, equipment.proddate, equipment.state,equipment.inputer, equipment.other FROM equipment INNER JOIN equiprlogo ON equipment.logoid = equiprlogo.logoid INNER JOIN equiprspec ON equipment.specid = equiprspec.specid where (equipment.typeid = {0}) AND (equipment.departid = {1})", typeid,departid);
                        }
                    }
                }
            }

            flylib.exsql eq = new exsql();
            DataSet ds = new DataSet();
            ds = eq.excuterdataset(selstr);

            报表管理.rpt.固定资产使用登记表 rpt = new EMS.报表管理.rpt.固定资产使用登记表();
            rpt.SetDataSource(ds.Tables[0]);
            TextObject type = rpt.ReportDefinition.ReportObjects["Text17"] as TextObject;
            type.Text = comboBox1.Text;
            TextObject depart = rpt.ReportDefinition.ReportObjects["Text13"] as TextObject;
            depart.Text = comboBox2.Text;
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
