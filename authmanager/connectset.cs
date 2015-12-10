/*************************************************************************************
 * Author:fly
 * Date:20090612
 * QQ:421666621
 * E-mail:yafei@post.com
 * Ver:1.0.0
 * Operation:
 * Description:此代码仅攻研究，如需商业使用请联系作者本人！欢迎大家将bug和建议汇报给fly，
 * 同时此代码最新版本可以在http://mian8king.bokee.com上免费下载！
 * fly@ 2009 All rights reserved
 * lastedit:
 * ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using flylib;

namespace authmanager
{
    public partial class connectset : Form
    {
        public string settypestring, setconinfostr,testconstr;
        sysinfo ss = new sysinfo();
        public connectset()
        {
            InitializeComponent();
        }

        private void connectset_Load(object sender, EventArgs e)
        {
            sysinfo ss=new sysinfo();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox6.Text = ss.getconstr();
            textBox6.ReadOnly = true;
        }
        private void settype(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            if (radioButton1.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                settypestring = "update info set [value]='1' where id='1'";
                setconinfostr = string.Format("update dbconfig set host='{0}',db='{1}',username='{2}',userpass='{3}' where id='1'", textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
            }
            if (radioButton2.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                settypestring = "update info set [value]='2' where id='1'";
                setconinfostr = string.Format("update dbconfig set host='{0}',db='{1}' where id='2'",textBox1.Text.Trim(),textBox2.Text.Trim());
            }
            
            if (radioButton3.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = true;
                settypestring = "update info set [value]='3' where id='1'";
                setconinfostr = string.Format("update dbconfig set custom='{0}' where id='3'",textBox5.Text.Trim());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text =="local")
            {
                textBox1.Text = "(local)";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testconstr = this.getconstr();
            if (testconstr == "")
            {
                MessageBox.Show("连接字符串为空！请输入！");
            }
            else
            {
                SqlConnection con = new SqlConnection(testconstr);
                try
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        MessageBox.Show("测试成功！");
                    }
                    else
                    {
                        MessageBox.Show("测试失败！");
                    }
                }
                catch (SqlException se)
                {
                    MessageBox.Show("测试失败！");
                    MessageBox.Show("失败原因:" + se.Message);
                }
            }
        }
        string getconstr()
        {
            string constr;
            if (radioButton1.Checked)
            {
                constr = "Data Source=" + textBox1.Text.Trim() + ";Initial Catalog=" + textBox2.Text.Trim() + ";User ID=" + textBox3.Text.Trim() + ";Password=" + textBox4.Text.Trim() + "";
                MessageBox.Show(constr);
                return constr;
            }
            if (radioButton2.Checked)
            {
                constr = "Data Source=" + textBox1.Text.Trim() + ";Initial Catalog=" + textBox2.Text.Trim() + ";Integrated Security=True";
                MessageBox.Show(constr);
                return constr;
            }

            if (radioButton3.Checked)
            {
                constr = textBox5.Text.Trim();
                MessageBox.Show(constr);
                return constr;
            }
            
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                settypestring = "update info set [value]='1' where id='1'";
                setconinfostr = string.Format("update dbconfig set host='{0}',db='{1}',username='{2}',userpass='{3}' where id='1'", textBox1.Text.Trim(), textBox2.Text.Trim(), textBox3.Text.Trim(), textBox4.Text.Trim());
            }
            if (radioButton2.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                settypestring = "update info set [value]='2' where id='1'";
                setconinfostr = string.Format("update dbconfig set host='{0}',db='{1}' where id='2'", textBox1.Text.Trim(), textBox2.Text.Trim());
            }

            if (radioButton3.Checked)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = true;
                settypestring = "update info set [value]='3' where id='1'";
                setconinfostr = string.Format("update dbconfig set custom='{0}' where id='3'", textBox5.Text.Trim());
            }
            testconstr = this.getconstr();
            SqlConnection con = new SqlConnection(testconstr);
            try
            {
                con.Open();
                
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    if (ss.setlocalinfo(setconinfostr))
                    {
                        if (ss.setlocalinfo(settypestring))
                        {
                            MessageBox.Show("设置成功！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("设置失败！");
                    }
                }
                else
                {
                    MessageBox.Show("当前连接设置存在问题，不能保存！");
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("当前连接设置存在问题，不能保存！失败原因:" + se.Message + "，不能保存！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}