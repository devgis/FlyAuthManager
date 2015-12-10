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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            percheck pk = new percheck();
            string username = textBox1.Text;
            int signid=pk.usercheck(textBox1.Text.Trim(), textBox2.Text.Trim());
            switch(signid)
            {
                case 0:
                    textBox1.Text = "";
                    textBox2.Text = "";
                    //main mn = new main();
                    //mn.sysusername = username;
                    main mn = new main();
                    this.Hide();
                    mn.Show();
                    break;
                case 1:
                    MessageBox.Show("用户名不能为空！");
                    break;
                case 2:
                    MessageBox.Show("密码不能为空！");
                    break;
                case 3:
                    MessageBox.Show("数据库异常,或者当前记录不存在！");
                    break;
                case 4:
                    MessageBox.Show("用户密码错误！");
                    break;
                case 5:
                    MessageBox.Show("该用户已被禁用！");
                    break;
                default:
                    MessageBox.Show("未知错误！");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;//设置回车键时使用的按纽
        }

        private void label4_Click(object sender, EventArgs e)
        {
    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connectset csn = new connectset();
            csn.Show();
        }
    }
}