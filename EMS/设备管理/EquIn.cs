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
    public partial class EquIn : Form
    {
        public string username;
        public int userid;
        public EquIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("设备编号或名称不能为空！");
            }
            else
            {
                string sn = textBox1.Text.Trim();
                string equipname = textBox2.Text.Trim();
                int typeid = Convert.ToInt32(comboBox1.SelectedValue);
                int logoid = Convert.ToInt32(comboBox2.SelectedValue);
                int specid = Convert.ToInt32(comboBox3.SelectedValue);
                int propid=Convert.ToInt32(comboBox5.SelectedValue);
                string proddate = dateTimePicker1.Value.ToString("yyyyMMdd");
                int departid = Convert.ToInt32(comboBox4.SelectedValue);
                string other = textBox3.Text.Trim();

                string instr = string.Format("insert into equipment(sn,equipname,typeid,logoid,specid,proddate,departid,other,propid)values('{0}','{1}',{2},{3},{4},'{5}',{6},'{7}',{8})", sn, equipname, typeid, logoid, specid, proddate, departid, other, propid);
                exsql eq = new exsql();
                eq.excutesql(instr);
                MessageBox.Show("插入成功！");
            }
        }

        private void EquIn_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.useprop”中。您可以根据需要移动或移除它。
            this.usepropTableAdapter.Fill(this.eMSDS.useprop);
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.eMSDS.department);
            // TODO: 这行代码将数据加载到表“eMSDS.equiprspec”中。您可以根据需要移动或移除它。
            this.equiprspecTableAdapter.Fill(this.eMSDS.equiprspec);
            // TODO: 这行代码将数据加载到表“eMSDS.equiprlogo”中。您可以根据需要移动或移除它。
            this.equiprlogoTableAdapter.Fill(this.eMSDS.equiprlogo);
            // TODO: 这行代码将数据加载到表“eMSDS.equiptype”中。您可以根据需要移动或移除它。
            this.equiptypeTableAdapter.Fill(this.eMSDS.equiptype);

            label12.Text = DateTime.Now.ToString("yyyyMMdd");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
