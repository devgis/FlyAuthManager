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

namespace EMS.基础资料
{
    public partial class EquSpc : Form
    {
        exsql eq = new exsql();
        EMS.cs.EMSDS ds = new EMS.cs.EMSDS();
        EMS.cs.EMSDSTableAdapters.equiprspecTableAdapter da = new EMS.cs.EMSDSTableAdapters.equiprspecTableAdapter();
        
        public EquSpc()
        {
            InitializeComponent();
        }

        private void EquSpc_Load(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("名称不能为空！");
            }
            else
            {
                //字符串常变量定义
                string specname = textBox1.Text.Trim();
                string checkstring = string.Format("select count(*) from equiprspec where specname='{0}'", specname); //判断记录是不是存在语句
                string instr = string.Format("insert into equiprspec(specname)values('{0}')", specname);//执行插入语句

                //判断是否有该记录
                SqlDataReader reader = eq.excutereader(checkstring);
                reader.Read();
                int count = Convert.ToInt32(reader[0]);
                if (count > 0)
                {
                    MessageBox.Show(specname + " 已存在！");
                }
                else
                {
                    eq.excutesql(instr);
                    MessageBox.Show("插入成功！");
                }

                UpdateView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //字符串常变量定义
            string sspecid = textBox2.Text.Trim();
            int specid = Convert.ToInt32(sspecid); //依据编号进行删除
            string checkstring = string.Format("select count(*) from equiprspec where specid={0}", specid); //判断记录是不是存在语句
            string delstr = string.Format("delete from equiprspec where specid={0}", specid);//执行删除语句

            //判断是否有该记录
            SqlDataReader reader = eq.excutereader(checkstring);
            reader.Read();
            int count = Convert.ToInt32(reader[0]);

            //不存在记录
            if (count == 0)
            {
                MessageBox.Show("编号为" + specid.ToString() + "的类型不存在！");
            }
            //执行删除
            else
            {
                eq.excutesql(delstr);
                MessageBox.Show("删除成功！");
            }
            UpdateView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //更新数据库
            da.Update(ds);
            ds.AcceptChanges();
            MessageBox.Show("更新成功!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateView()
        {

            //填充数据
            da.Fill(ds.equiprspec);
            dataGridView1.DataSource = ds.equiprspec;

            //设置布局
            dataGridView1.Columns[0].HeaderText = "规格编号";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].HeaderText = "规格名称";
            dataGridView1.Columns[1].Width = 264;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int typeid = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException)
            {
                textBox2.Text = "";
            }
        }
    }
}
