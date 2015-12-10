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
    public partial class editrole : Form
    {
        exsql eq = new exsql();
        public editrole()
        {
            InitializeComponent();
        }

        private void editrole_Load(object sender, EventArgs e)
        {
            string cmdstr="select role from role";
            SqlDataReader reader=eq.excutereader(cmdstr);
            while (reader.Read())
            {
            	TreeNode tn = new TreeNode();
                tn.Text = reader[0].ToString();
                treeView1.Nodes.Add(tn);
                int rid = eq.selid(tn.Text, 1);

                tn.Checked = true;
                cmdstr = "SELECT authority FROM authority";
                SqlDataReader reader2 = eq.excutereader(cmdstr);
                while (reader2.Read())
                {
                    TreeNode tn2 = new TreeNode();
                    tn2.Text = reader2[0].ToString();
                    tn.Nodes.Add(tn2);
                    int aid = eq.selid(tn2.Text, 2);

                    cmdstr = string.Format("select count(*) from roleauthority where (roleid={0} and authorityid={1})", rid, aid);
                    SqlDataReader reader3 = eq.excutereader(cmdstr);
                    reader3.Read();
                    int count = Convert.ToInt32(reader3[0]);
                    reader3.Close();
                    if (count > 0)
                    {
                        tn2.Checked = true;
                    }
                }
            }
            
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level== 1)
            {
                int rid = eq.selid(e.Node.Parent.Text, 1);
                int aid = eq.selid(e.Node.Text, 2);
                if (e.Node.Checked == true) //添加所有权限到该角色
                {
                    string cmdstr = string.Format("select count(*) from roleauthority where (roleid={0} and authorityid={1})", rid,aid);
                    SqlDataReader reader = eq.excutereader(cmdstr);
                    reader.Read();
                    int count = Convert.ToInt32(reader[0]);
                    reader.Close();
                    if (count == 0)
                    {
                        cmdstr = string.Format("insert into roleauthority(roleid,authorityid)values({0},{1})", rid, aid);
                        eq.excutesql(cmdstr);
                        MessageBox.Show("添加成功！");
                    }
                }
                else //取消该组所有权限
                {
                    string cmdstr = string.Format("select count(*) from roleauthority where (roleid={0} and authorityid={1})", rid, aid);
                    SqlDataReader reader = eq.excutereader(cmdstr);
                    reader.Read();
                    int count = Convert.ToInt32(reader[0]);
                    reader.Close();
                    if (count > 0)
                    {
                        cmdstr = string.Format("delete from roleauthority where (roleid={0} and authorityid={1})", rid, aid);
                        eq.excutesql(cmdstr);
                        MessageBox.Show("删除成功!");
                    }
                }
            }
        }
    }
}