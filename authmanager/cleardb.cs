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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using flylib;

namespace authmanager
{
    public partial class cleardb : Form
    {
        string sqlstr;
        exsql eq = new exsql();
        public cleardb()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backupdatabase bkd = new backupdatabase();
            bkd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                sqlstr = "delete from [user];delete from role;delete from userper;delete from userrole;delete from roleauthority;delete from authsub";
                eq.excutesql(sqlstr);
                sqlstr = "insert into [user] (username,userpassword,userstate)values('admin','admin','1')";
                eq.excutesql(sqlstr);
                MessageBox.Show("清空数据库所有信息成功!并将用户初始为“用户名：admin 密码admin”！");
            }
            else
            {
                if (checkBox1.Checked)
                {
                    sqlstr = "delete from [user];delete from userrole;delete from userper";
                    eq.excutesql(sqlstr);
                    sqlstr = "insert into [user] (username,userpassword,userstate)values('admin','admin','1')";
                    eq.excutesql(sqlstr);
                    MessageBox.Show("清除用户信息成功!并将用户初始为“用户名：admin 密码admin”！");
                }
                if (checkBox2.Checked)
                {
                    sqlstr = "delete from role;delete from authsub;delete from userper";
                    eq.excutesql(sqlstr);
                    MessageBox.Show("清除权限信息成功!");
                }
                if (checkBox4.Checked)
                {
                    sqlstr = "delete from authsub;delete from userper";
                    eq.excutesql(sqlstr);
                    MessageBox.Show("清除子权限信息成功!");
                }
                if (checkBox5.Checked)
                {
                    sqlstr = "delete from role;delete from userrole;delete from roleauthority;delete from userper";
                    eq.excutesql(sqlstr);
                    MessageBox.Show("清除角色信息成功!");
                }
            }
        }
    }
}