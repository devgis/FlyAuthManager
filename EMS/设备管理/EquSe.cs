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
    public partial class EquSe : Form
    {
        DataSet ds = new DataSet();
        exsql eq = new exsql();
        public EquSe()
        {
            InitializeComponent();
        }

        private void EquSe_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eMSDS.equiptype”中。您可以根据需要移动或移除它。
            this.equiptypeTableAdapter.Fill(this.eMSDS.equiptype);
            // TODO: 这行代码将数据加载到表“eMSDS.equiprlogo”中。您可以根据需要移动或移除它。
            this.equiprlogoTableAdapter.Fill(this.eMSDS.equiprlogo);
            // TODO: 这行代码将数据加载到表“eMSDS.equiprspec”中。您可以根据需要移动或移除它。
            this.equiprspecTableAdapter.Fill(this.eMSDS.equiprspec);
            // TODO: 这行代码将数据加载到表“eMSDS.department”中。您可以根据需要移动或移除它。
            this.departmentTableAdapter.Fill(this.eMSDS.department);
            // TODO: 这行代码将数据加载到表“eMSDS.equiprspec”中。您可以根据需要移动或移除它。
            this.equiprspecTableAdapter.Fill(this.eMSDS.equiprspec);
            // TODO: 这行代码将数据加载到表“eMSDS.equiprlogo”中。您可以根据需要移动或移除它。
            this.equiprlogoTableAdapter.Fill(this.eMSDS.equiprlogo);
            // TODO: 这行代码将数据加载到表“eMSDS.equiptype”中。您可以根据需要移动或移除它。
            this.equiptypeTableAdapter.Fill(this.eMSDS.equiptype);
            string selstr = "SELECT equipment.equipid, equipment.sn, equipment.equipname, equiptype.typename,equiprlogo.logoname, equiprspec.specname, department.departname,equipment.proddate, equipment.other FROM equipment INNER JOIN equiptype ON equipment.typeid = equiptype.typeid INNER JOIN equiprlogo ON equipment.logoid = equiprlogo.logoid INNER JOIN equiprspec ON equipment.specid = equiprspec.specid INNER JOIN department ON equipment.departid = department.departid";
            ds = eq.excuterdataset(selstr);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "序号";
            dataGridView1.Columns[1].HeaderText = "设备编号";
            dataGridView1.Columns[2].HeaderText = "设备名称";
            dataGridView1.Columns[3].HeaderText = "设备类别";
            dataGridView1.Columns[4].HeaderText = "设备品牌";
            dataGridView1.Columns[5].HeaderText = "设备规格";
            dataGridView1.Columns[6].HeaderText = "所属部门";
            dataGridView1.Columns[7].HeaderText = "出厂日期";
            dataGridView1.Columns[8].HeaderText = "备注信息";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sn = textBox1.Text.Trim();
            string equipname = textBox2.Text.Trim();
            string type = comboBox1.Text;
            string logo = comboBox2.Text;
            string spec = comboBox3.Text;
            string depart = comboBox4.Text;

            string selstr = string.Format("SELECT equipment.equipid, equipment.sn, equipment.equipname, equiptype.typename,equiprlogo.logoname, equiprspec.specname, department.departname,equipment.proddate, equipment.other FROM equipment INNER JOIN equiptype ON equipment.typeid = equiptype.typeid INNER JOIN equiprlogo ON equipment.logoid = equiprlogo.logoid INNER JOIN equiprspec ON equipment.specid = equiprspec.specid INNER JOIN department ON equipment.departid = department.departid WHERE (equipment.sn LIKE '%{0}%') AND (equipment.equipname LIKE '%{1}%') AND (equiptype.typename LIKE '%{2}%') AND (equiprlogo.logoname LIKE '%{3}%') AND (equiprspec.specname LIKE '%{4}%') AND (department.departname LIKE '%{5}%')", sn,equipname,type,logo,spec,depart);
            ds = eq.excuterdataset(selstr);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].HeaderText = "序号";
            dataGridView1.Columns[1].HeaderText = "设备编号";
            dataGridView1.Columns[2].HeaderText = "设备名称";
            dataGridView1.Columns[3].HeaderText = "设备类别";
            dataGridView1.Columns[4].HeaderText = "设备品牌";
            dataGridView1.Columns[5].HeaderText = "设备规格";
            dataGridView1.Columns[6].HeaderText = "所属部门";
            dataGridView1.Columns[7].HeaderText = "出厂日期";
            dataGridView1.Columns[8].HeaderText = "备注信息";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
