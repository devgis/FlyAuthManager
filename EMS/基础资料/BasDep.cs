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
    public partial class BasDep : Form
    {
        exsql eq = new exsql();
        EMS.cs.EMSDS ds = new EMS.cs.EMSDS();
        EMS.cs.EMSDSTableAdapters.departmentTableAdapter da = new EMS.cs.EMSDSTableAdapters.departmentTableAdapter();
        
        public BasDep()
        {
            InitializeComponent();
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
                string departname = textBox1.Text.Trim();
                string checkstring = string.Format("select count(*) from department where departname='{0}'", departname); //判断记录是不是存在语句
                string instr = string.Format("insert into department(departname)values('{0}')", departname);//执行插入语句

                //判断是否有该记录
                SqlDataReader reader = eq.excutereader(checkstring);
                reader.Read();
                int count = Convert.ToInt32(reader[0]);
                if (count > 0)
                {
                    MessageBox.Show(departname + " 已存在！");
                }
                else
                {
                    eq.excutesql(instr);
                    MessageBox.Show("插入成功！");
                }

                UpdateView();
            }
        }

        private void BasDep_Load(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //字符串常变量定义
            string sdepartid = textBox2.Text.Trim();
            //MessageBox.Show(sdepartid);
            int departid = Convert.ToInt32(sdepartid); //依据编号进行删除
            string checkstring = string.Format("select count(*) from department where departid={0}", departid); //判断记录是不是存在语句
            string delstr = string.Format("delete from department where departid={0}", departid);//执行删除语句

            //判断是否有该记录
            SqlDataReader reader = eq.excutereader(checkstring);
            reader.Read();
            int count = Convert.ToInt32(reader[0]);

            //不存在记录
            if (count == 0)
            {
                MessageBox.Show("编号为" + departid.ToString()+ "的部门不存在！");
            }
                //执行删除
            else
            {
                eq.excutesql(delstr);
                MessageBox.Show("删除成功！");
            }
            UpdateView();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int departid = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException)
            {
                textBox2.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateView()
        {
            //填充数据
            //string selstring = "select * from department";
            da.Fill(ds.department);
            dataGridView1.DataSource = ds.Tables[0];

            //设置布局
            dataGridView1.Columns[0].HeaderText = "部门编号";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].HeaderText = "部门名称";
            dataGridView1.Columns[1].Width =247;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //更新数据库
            da.Update(ds.department);
            ds.AcceptChanges();
            MessageBox.Show("更新成功!");
        }
    }
}