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
    public partial class adduser : Form
    {
        public string username;
        
        exsql eq = new exsql();
        public adduser()
        {
            InitializeComponent();
        }

        private void adduser_Load(object sender, EventArgs e)
        {
            string cmdstr = "select role from role";
            SqlDataReader reader=eq.excutereader(cmdstr);
            while (reader.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Text = reader[0].ToString();
                treeView1.Nodes.Add(tn);
            }
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //检查用户名是否存在，如不存在则插入用户用户名并将选择的角色授于该用户；
            if (textBox1.Text != "")
            {
                string cmdstr = string.Format("select count(*) from [user] where username='{0}'", textBox1.Text.Trim());
                SqlDataReader reader = eq.excutereader(cmdstr);
                reader.Read();
                int count = Convert.ToInt32(reader[0].ToString());
                if (count == 0)
                {
                    cmdstr = string.Format("insert into [user](username,userpassword,userstate)values('{0}','{1}',{2})", textBox1.Text, textBox2.Text, 0);
                    eq.excutesql(cmdstr);
                    int uid = eq.selid(textBox1.Text,0);
                    foreach (TreeNode td in treeView1.Nodes)
                    {
                        if (td.Checked)
                        {
                            int rid = eq.selid(td.Text, 1);
                            string instr = string.Format("insert into userrole(userid,roleid)values({0},{1})", uid, rid);
                            eq.excutesql(instr);
                        }
                    }

                    MessageBox.Show("插入成功！");
                    username = this.textBox1.Text;
                    this.DialogResult =DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("用户名已存在！");
                    textBox1.Text = "";
                }

            }
            else
            {
                MessageBox.Show("请输入用户名!");
            }
        }
    }
}