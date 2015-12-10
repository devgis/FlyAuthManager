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
    public partial class EquLog : Form
    {
        exsql eq = new exsql();
        EMS.cs.EMSDS ds = new EMS.cs.EMSDS();
        EMS.cs.EMSDSTableAdapters.equiprlogoTableAdapter da = new EMS.cs.EMSDSTableAdapters.equiprlogoTableAdapter();

        public EquLog()
        {
            InitializeComponent();
        }
        private void EquLog_Load(object sender, EventArgs e)
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
                string logoname = textBox1.Text.Trim();
                string checkstring = string.Format("select count(*) from equiprlogo where logoname='{0}'", logoname); //判断记录是不是存在语句
                string instr = string.Format("insert into equiprlogo(logoname)values('{0}')", logoname);//执行插入语句

                //判断是否有该记录
                SqlDataReader reader = eq.excutereader(checkstring);
                reader.Read();
                int count = Convert.ToInt32(reader[0]);
                if (count > 0)
                {
                    MessageBox.Show(logoname + " 已存在！");
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
            string slogoid = textBox2.Text.Trim();
            int logoid = Convert.ToInt32(slogoid); //依据编号进行删除
            string checkstring = string.Format("select count(*) from equiprlogo where  logoid={0}", logoid); //判断记录是不是存在语句
            string delstr = string.Format("delete from equiprlogo where logoid={0}", logoid);//执行删除语句

            //判断是否有该记录
            SqlDataReader reader = eq.excutereader(checkstring);
            reader.Read();
            int count = Convert.ToInt32(reader[0]);

            //不存在记录
            if (count == 0)
            {
                MessageBox.Show("编号为" + slogoid + "的类型不存在！");
            }
            //执行删除
            else
            {
                eq.excutesql(delstr);
                MessageBox.Show("删除成功！");
            }
            UpdateView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void button3_Click(object sender, EventArgs e)
        {
            //更新数据库
            //da.Update(ds.equiprlogo);
            //ds.AcceptChanges();

            da.Update(ds.equiprlogo);
            ds.AcceptChanges();
            MessageBox.Show("更新成功!");
        }
        private void UpdateView()
        {

            //填充数据
            da.Fill(ds.equiprlogo);
            dataGridView1.DataSource = ds.equiprlogo;

            //设置布局
            dataGridView1.Columns[0].HeaderText = "品牌编号";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].HeaderText = "品牌名称";
            dataGridView1.Columns[1].Width = 264;
        }
    }
}
