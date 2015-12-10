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
    public partial class adduserrole : Form
    {
        public string seluser;
        exsql eq = new exsql();
        public adduserrole()
        {
            InitializeComponent();
        }

        private void adduserrole_Load(object sender, EventArgs e)
        {
            int uid = eq.selid(seluser, 0);
            string cmdstr = "select role from role";
            SqlDataReader reader = eq.excutereader(cmdstr);
            while(reader.Read())
            {
                TreeNode tn=new TreeNode();
                tn.Text=reader[0].ToString();
                treeView1.Nodes.Add(tn);

                int rid = eq.selid(tn.Text, 1);
                cmdstr = string.Format("select count(*) from userrole where (userid={0} and roleid={1})",uid,rid);
                SqlDataReader reader2 = eq.excutereader(cmdstr);
                reader2.Read();
                int rcount = Convert.ToInt32(reader2[0]);
                if (rcount ==1)
                {
                    tn.Checked = true;
                }

            }
            reader.Close();
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int uid = eq.selid(seluser, 0);
            int rid = eq.selid(e.Node.Text, 1);
            
            if (e.Node.Checked == true)
            {
                string cmdstr = string.Format("select count(*) from userrole where (userid={0} and roleid={1})", uid, rid);
                SqlDataReader reader = eq.excutereader(cmdstr);
                reader.Read();
                int count = Convert.ToInt32(reader[0]);
                reader.Close();
                if (count == 0)
                {
                    cmdstr = string.Format("insert into userrole(userid,roleid)values({0},{1})", uid, rid);
                    eq.excutesql(cmdstr);
                    MessageBox.Show(seluser + "用户添加" + e.Node.Text + "角色成功!");
                }
            }
            else
            {
                string cmdstr = string.Format("select count(*) from userrole where (userid={0} and roleid={1})", uid, rid);
                SqlDataReader reader = eq.excutereader(cmdstr);
                reader.Read();
                int count = Convert.ToInt32(reader[0]);
                reader.Close();
                if (count > 0)
                {
                    cmdstr = string.Format("delete from userrole where (userid={0} and roleid={1})", uid, rid);
                    eq.excutesql(cmdstr);
                    MessageBox.Show(seluser + "用户删除" + e.Node.Text + "角色成功!");
                }
            }
        }

        private void adduserrole_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}