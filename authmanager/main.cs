/*************************************************************************************
 * Author:fly
 * Date:20090916
 * QQ:421666621
 * E-mail:yafei@post.com
 * Ver:1.0.1
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
    public partial class main : Form
    {
        string selstr;
        public string seluser;//当前编辑的用户
        TreeNode tnd = new TreeNode();
        exsql eq = new exsql();
        sysinfo ss= new sysinfo();

        public string sysusername;
        

        public main()
        {
            InitializeComponent();
        }

        private void user2_Load(object sender, EventArgs e)
        {
            /****************************************************************************************
             * 初始化权限树
             * ****************************************************************************************/

            sysuser.Text ="当前用户:"+sysusername;
            datetiem.Text = DateTime.Now.ToString("yyyy年MM月dd日tthh:mm:ss");
            timer1.Enabled = true;
            timer1.Interval = 1000;

            string cmdstr = "select username,userstate from [user]";//用户结点初始化
            SqlDataReader reader;
            reader=eq.excutereader(cmdstr); //读用户
            int uid, rid, aid;
            while (reader.Read())
            {
                TreeNode tn = new TreeNode();
                tn.Text = reader[0].ToString();
                if (reader[1].ToString() == "1")
                    tn.Checked = true;
                else
                    tn.Checked = false;
                uid = eq.selid(tn.Text, 0);

                //string cmdstr2 = "select role from role";
                string cmdstr2 = string.Format("select role.role from role,userrole,[user] where role.roleid=userrole.roleid and userrole.userid=[user].userid and [user].username='{0}'", tn.Text);
                SqlDataReader reader2;
                reader2 = eq.excutereader(cmdstr2);
                while(reader2.Read())
                {
                    TreeNode t2 = new TreeNode();
                    t2.Text = reader2[0].ToString();
                    rid = eq.selid(t2.Text, 1);
                    int rcount = eq.selcount(uid, rid);
                    if (rcount > 0)
                    {
                        t2.Checked = true;
                    }
                    else
                    {
                        t2.Checked = false;
                    }

                    SqlDataReader reader3;
                    string cmdstr3 = string.Format("SELECT authority.authority FROM role, roleauthority, authority WHERE (role.roleid=roleauthority.roleid and roleauthority.authorityid=authority.authorityid and role.role='{0}')", t2.Text);
                    reader3 = eq.excutereader(cmdstr3);
                    while (reader3.Read())
                    {
                        TreeNode t3 = new TreeNode();
                        t3.Text = reader3[0].ToString();
                        t2.Nodes.Add(t3);
                        aid = eq.selid(t3.Text, 2);
                        rcount = eq.selcount(uid, rid,aid);
                        if (rcount > 0)
                        {
                            t3.Checked = true;
                        }
                        else
                        {
                            t3.Checked = false;
                        }
                    }
                    reader3.Close();

                    tn.Nodes.Add(t2);
                }
                reader2.Close();
                if (reader[1].ToString() == "1")
                {
                    tn.Checked = true;
                }
                else
                {
                    tn.Checked = false;
                }
                treeView1.Nodes.Add(tn);
            }
            reader.Close();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeView1.SelectedNode.Level)
            {
                case 0: selstr = string.Format("SELECT [user].username, role.role, authority.authority, subauthority.subauthority FROM [user] INNER JOIN ((subauthority INNER JOIN (role INNER JOIN ((authority INNER JOIN authsub ON authority.authorityid = authsub.authorityid) INNER JOIN roleauthority ON authority.authorityid = roleauthority.authorityid) ON role.roleid = roleauthority.roleid) ON subauthority.subauthorityid = authsub.subauthorityid) INNER JOIN userrole ON role.roleid = userrole.roleid) ON [user].userid = userrole.userid WHERE [user].username='{0}'", e.Node.Text);
                    seluser = e.Node.Text;
                    eq.excutesql(selstr);
                    break;
                case 1: selstr = String.Format("SELECT [user].username, role.role, authority.authority, subauthority.subauthority FROM [user] INNER JOIN ((subauthority INNER JOIN (role INNER JOIN ((authority INNER JOIN authsub ON authority.authorityid = authsub.authorityid) INNER JOIN roleauthority ON authority.authorityid = roleauthority.authorityid) ON role.roleid = roleauthority.roleid) ON subauthority.subauthorityid = authsub.subauthorityid) INNER JOIN userrole ON role.roleid = userrole.roleid) ON [user].userid = userrole.userid WHERE ([user].username='{0}' and role.role='{1}')", e.Node.Parent.Text, e.Node.Text);
                    seluser = e.Node.Parent.Text;
                    eq.excutesql(selstr);
                    break;
                case 2: selstr = String.Format("SELECT [user].username, role.role, authority.authority, subauthority.subauthority FROM [user] INNER JOIN ((subauthority INNER JOIN (role INNER JOIN ((authority INNER JOIN authsub ON authority.authorityid = authsub.authorityid) INNER JOIN roleauthority ON authority.authorityid = roleauthority.authorityid) ON role.roleid = roleauthority.roleid) ON subauthority.subauthorityid = authsub.subauthorityid) INNER JOIN userrole ON role.roleid = userrole.roleid) ON [user].userid = userrole.userid WHERE ([user].username='{0}' and role.role='{1}' and authority.authority='{2}')", e.Node.Parent.Parent.Text, e.Node.Parent.Text, e.Node.Text);
                    seluser = e.Node.Parent.Parent.Text;
                    eq.excutesql(selstr);
                    break;
            }
            DataSet ds;
            ds = eq.excuterdataset(selstr);

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["权限"].DisplayIndex = 4;
            dataGridView1.Columns["username"].HeaderText = "用户名";
            dataGridView1.Columns["username"].ReadOnly = true;
            dataGridView1.Columns["subauthority"].HeaderText = "子权限";
            dataGridView1.Columns["subauthority"].ReadOnly = true;
            dataGridView1.Columns["role"].HeaderText = "角色";
            dataGridView1.Columns["role"].ReadOnly = true;
            dataGridView1.Columns["authority"].HeaderText = "窗体";
            dataGridView1.Columns["authority"].ReadOnly = true;
            dataGridView1.Columns["subauthority"].ReadOnly = true;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                int uid = eq.selid(dr.Cells["username"].Value.ToString(), 0);
                int rid = eq.selid(dr.Cells["role"].Value.ToString(),1);
                int aid = eq.selid(dr.Cells["authority"].Value.ToString(), 2);
                int sid = eq.selid(dr.Cells["subauthority"].Value.ToString(), 3);

                int count = eq.selcount(uid, rid, aid, sid);
                if (count > 0)
                {
                    dr.Cells["权限"].Value = "yes";
                }
            }
            //dataGridView1.RowHeadersVisible = false;//隐藏第一列空列
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int uid, rid, aid, sid;
            string operstr;
            string ustr;

            if (e.Node.Checked.ToString() == "False")
            {
                
                /*****************************************************
                 * checkbox取消时执行此操作
                 * **************************************************/
                //删除操作
                switch (e.Node.Level)
                {
                    case 0:
                        //用户禁用
                        operstr = string.Format("update [user] set userstate=0 where username='{0}'",e.Node.Text);//更新用户状态为无效
                        eq.excutesql(operstr);
                        break;
                    case 1:
                        //删除角色下所有权限
                        uid=eq.selid(e.Node.Parent.Text,0);
                        sid=eq.selid(e.Node.Text,1);
                        operstr = string.Format("delete from userper where (userid={0} and roleid={1})", uid,sid);//则选中的节点为角色结点，则删除该用户，该角色下的所有权限，子权限
                        eq.excutesql(operstr);
                        foreach (TreeNode td in e.Node.Nodes)
                        {
                            td.Checked = false;
                        }
                        //operstr = string.Format("delete * from userper where (userper.userid in (select userid from [user] where [user].username='{0}') and userper.roleid in (select roleid from [role] where [role].role='{1}'))", e.Node.Parent.Text);//则选中的节点为角色结点，则删除该用户，该角色下的所有权限，子权限
                        /*****************************************************************
                         * 去掉所有子结点的选中状态
                         * **************************************************************/
                        //删除datagridview中所有checkbox的选中
                        ustr = e.Node.Parent.Text;
                        break;
                    case 2:
                        //删除权限下所有子权限
                        uid=eq.selid(e.Node.Parent.Parent.Text,0);
                        sid=eq.selid(e.Node.Parent.Text,1);
                        aid=eq.selid(e.Node.Text,2);
                        operstr = string.Format("delete from userper where (userid={0} and roleid={1} and authorityid={2})", uid,sid,aid);//则选中的节点为角色结点，则删除该用户，该角色下，该权限下的的所有子权限
                        //删除datagridview中所有checkbox的选中
                        eq.excutesql(operstr);
                        ustr = e.Node.Parent.Parent.Text;
                        break;
                }
                foreach (DataGridViewRow dgw in dataGridView1.Rows)
                {
                    dgw.Cells["权限"].Value = "no";
                }
            }
            else
                //添加权限操作
            {
                /*****************************************************
                 * checkbox选中时执行此操作
                 * **************************************************/
                switch (e.Node.Level)
                {
                        //启动用户状态
                    case 0:
                        operstr = string.Format("update [user] set userstate=1 where username='{0}'", e.Node.Text);//更新用户状态有效
                        eq.excutesql(operstr);
                        ustr = e.Node.Text;
                        break;
                    //添加角色下的所有权限
                    case 1:
                        uid=eq.selid(e.Node.Parent.Text,0);
                        rid=eq.selid(e.Node.Text,1);
                        foreach(TreeNode td in e.Node.Nodes)
                        {
                            aid=eq.selid(td.Text,2);
                            foreach (DataGridViewRow dr in dataGridView1.Rows)
                            {
                                sid = eq.selid(dr.Cells["subauthority"].Value.ToString(), 3);
                                operstr = string.Format("insert into userper(userid,roleid,authorityid,subauthorityid) values({0},{1},{2},{3})", uid, rid, aid, sid);
                                eq.excutesql(operstr);
                            }
                        }
                        foreach (TreeNode td in e.Node.Nodes)
                        {
                            td.Checked = true;
                        }
                        ustr = e.Node.Parent.Text;
                        break;
                    //添加权限下的所有子权限
                    case 2:
                        //添加权限下所有子权限
                        uid=eq.selid(e.Node.Parent.Parent.Text,0);
                        rid=eq.selid(e.Node.Parent.Text,1);
                        aid=eq.selid(e.Node.Text,2);
                        foreach(DataGridViewRow dr in dataGridView1.Rows)
                        {
                            sid = eq.selid(dr.Cells["subauthority"].Value.ToString(), 3);
                            operstr = string.Format("insert into userper(userid,roleid,authorityid,subauthorityid) values({0},{1},{2},{3})", uid, rid, aid, sid);
                            eq.excutesql(operstr);
                        }
                        ustr = e.Node.Parent.Parent.Text;
                        break;
                }
                foreach (DataGridViewRow dgw in dataGridView1.Rows)
                {
                    dgw.Cells["权限"].Value = "yes";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //在datagridview中checkbox选中或取消时进行对数据库更新操作
            try {
                if (dataGridView1.SelectedCells[0] == dataGridView1.CurrentRow.Cells["权限"])               //判断单击的cell是不是复选框所在的cell如果不是则不进行任何操作
                {
                    string per = ((DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["权限"]).EditedFormattedValue.ToString();//取得checkbox的是否选中
                    string ustr = dataGridView1.CurrentRow.Cells["username"].Value.ToString();          //获取要更新的用户名字
                    string rstr = dataGridView1.CurrentRow.Cells["role"].Value.ToString();            //获取要更新的用户角色
                    string astr = dataGridView1.CurrentRow.Cells["authority"].Value.ToString();         //获取要更新的用户权限窗体
                    string sstr = dataGridView1.CurrentRow.Cells["subauthority"].Value.ToString();      //获取要更新的用户子权限
                    int uid = eq.selid(ustr, 0);            //获取用户的userid
                    int rid = eq.selid(rstr, 1);           //获取权限的roleid
                    int aid = eq.selid(astr, 2);           //获取权限窗体的authorityid
                    int sid = eq.selid(sstr, 3);           //获取子权限的subauthorityid
                    if (per == "True")                  //如果复选框为选中状态则执行增加权限
                    {
                        string insertsubstr = string.Format("insert into userper(userid,roleid,authorityid,subauthorityid) values({0},{1},{2},{3})", uid, rid, aid, sid);
                        eq.excutesql(insertsubstr);             //执行添加权限
                    }
                    else                                        //如果复选框为未选中状态则执行删除权限
                    {
                        string delsubstr = string.Format("delete from userper where (userid={0} and roleid ={1} and authorityid={2} and subauthorityid={3})", uid, rid, aid, sid);
                        eq.excutesql(delsubstr);                    //执行删除权限
                    }
                }
                else { }
            }
            catch(ArgumentOutOfRangeException){}
            
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adduser au = new adduser();
            au.ShowDialog();
            if (au.DialogResult == DialogResult.OK)
            {
                //增加用户后添加为他所选择的角色，权限等。
                TreeNode tn = new TreeNode();
                tn.Text = au.username;
                treeView1.Nodes.Add(tn);

                int userid=eq.selid(tn.Text,0);
                string sqlstr = string.Format("SELECT dbo.role.role FROM dbo.userrole INNER JOIN dbo.role ON dbo.userrole.roleid = dbo.role.roleid WHERE (dbo.userrole.userid = {0})",userid);
                SqlDataReader reader2;
                reader2 = eq.excutereader(sqlstr);
                while (reader2.Read())
                {
                    TreeNode t2 = new TreeNode();
                    t2.Text = reader2[0].ToString();
                    tn.Nodes.Add(t2);

                    int rid = eq.selid(t2.Text, 1);
                    SqlDataReader reader3;
                    string cmdstr3 = string.Format("SELECT dbo.authority.authority FROM dbo.role INNER JOIN dbo.roleauthority ON dbo.role.roleid = dbo.roleauthority.roleid INNER JOIN dbo.authority ON dbo.roleauthority.authorityid = dbo.authority.authorityid WHERE (dbo.role.roleid = {0})", rid);
                    reader3 = eq.excutereader(cmdstr3);
                    while (reader3.Read())
                    {
                        TreeNode t3 = new TreeNode();
                        t3.Text = reader3[0].ToString();
                        t2.Nodes.Add(t3);
                    }
                    reader3.Close();
                }
                reader2.Close();
            }
        }

        private void 新建角色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newrole nw = new newrole();
            nw.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
            {
                seluser = treeView1.SelectedNode.Text;
                changepassword cp = new changepassword();
                cp.seluser = this.seluser;
                cp.Show();
            }
            else
            {
                MessageBox.Show("请选中要更改的用户");
            }
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
            {
                seluser = treeView1.SelectedNode.Text;
                int uid=eq.selid(seluser,0);
                string cmd1 = string.Format("delete from userper where userid={0}", uid);
                string cmd2 = string.Format("delete from userrole where userid={0}", uid);
                string cmd3 = string.Format("delete from [user] where userid={0}", uid);
                eq.excutesql(cmd1);
                eq.excutesql(cmd2);
                eq.excutesql(cmd3);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("请选中要更改的用户");
            }
        }

        private void 删除用户权限ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 1)
            {
                seluser = treeView1.SelectedNode.Parent.Text;
                string rstr = treeView1.SelectedNode.Text;
                int uid = eq.selid(seluser, 0);
                int rid = eq.selid(rstr, 1);
                string cmd1 = string.Format("delete from userper where (userid={0} and roleid={1})", uid,rid);
                string cmd2 = string.Format("delete from userrole where (userid={0} and roleid={1})", uid,rid);
                eq.excutesql(cmd1);
                eq.excutesql(cmd2);
                treeView1.Nodes.Remove(treeView1.SelectedNode);
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("请选中要删除的角色");
            }
        }

        private void 添加角色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
            {
                seluser = treeView1.SelectedNode.Text;
                adduserrole adr = new adduserrole();
                adr.seluser = seluser;
                adr.ShowDialog();
                if (adr.DialogResult == DialogResult.OK)
                {
                    int userid = eq.selid(treeView1.SelectedNode.Text, 0);
                    TreeNode tn = treeView1.SelectedNode;
                    string sqlstr = string.Format("SELECT dbo.role.role FROM dbo.userrole INNER JOIN dbo.role ON dbo.userrole.roleid = dbo.role.roleid WHERE (dbo.userrole.userid = {0})", userid);
                    SqlDataReader reader2;
                    reader2 = eq.excutereader(sqlstr);
                    tn.Nodes.Clear();

                    while (reader2.Read())
                    {
                        TreeNode t2 = new TreeNode();
                        t2.Text = reader2[0].ToString();
                        tn.Nodes.Add(t2);

                        int rid = eq.selid(t2.Text, 1);
                        SqlDataReader reader3;
                        string cmdstr3 = string.Format("SELECT dbo.authority.authority FROM dbo.role INNER JOIN dbo.roleauthority ON dbo.role.roleid = dbo.roleauthority.roleid INNER JOIN dbo.authority ON dbo.roleauthority.authorityid = dbo.authority.authorityid WHERE (dbo.role.roleid = {0})", rid);
                        reader3 = eq.excutereader(cmdstr3);
                        while (reader3.Read())
                        {
                            TreeNode t3 = new TreeNode();
                            t3.Text = reader3[0].ToString();
                            t2.Nodes.Add(t3);
                        }
                        reader3.Close();
                    }
                    reader2.Close();
                }
            }
            else
            {
                MessageBox.Show("请选中要添加的用户");
            }
            
        }

        private void 编辑角色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editrole er = new editrole();
            er.Show();
        }

        private void 退出EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datetiem.Text = DateTime.Now.ToString("yyyy年MM月dd日tthh:mm:ss");
        }

        private void copyright_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        private void 备份数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backupdatabase bd = new backupdatabase();
            bd.Show();
        }

        private void 导入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            revertdatabase rd = new revertdatabase();
            rd.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            connectset cs = new connectset();
            cs.Show();
        }

        private void 清空数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleardb cd = new cleardb();
            cd.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            report rp = new report();
            rp.Show();
        }

        private void 帮助文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂无帮助文档，如需帮助或者您在使用中遇到bug请将这些问题或bug汇报给fly，请联系QQ：421666621或者发电子邮件到llyafei@163.com!!!");
        }
    }
}