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
    public partial class changepassword : Form
    {
        public string seluser;
        exsql eq = new exsql();
        public changepassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdstr = string.Format("update [user] set userpassword='{0}' where username='{1}'", textBox2.Text, label5.Text);
            eq.excutesql(cmdstr);
            MessageBox.Show("更改成功");
            this.Close();

        }

        private void changepassword_Load(object sender, EventArgs e)
        {
            label5.Text = seluser;
        }
    }
}