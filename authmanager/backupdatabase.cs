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
using System.IO;
using flylib;

namespace authmanager
{
    public partial class backupdatabase : Form
    {
        string databasename;
        flylib.sysinfo ss = new sysinfo();
        exsql eq = new exsql();

        public backupdatabase()
        {
            InitializeComponent();
            SqlConnection con = ss.getcon();
            databasename = con.Database;
            
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDSPath.Text = folderBrowserDialog1.SelectedPath.ToString().Trim() + "\\";
        }

        private void btnDStore_Click(object sender, EventArgs e)
        {
            if (txtDSPath.Text == "")
            {
                MessageBox.Show("请选择路径！");
            }
            else
            {
                try
                {
                    if (File.Exists(txtDSPath.Text.Trim() + ".bak"))
                    {
                        MessageBox.Show("该文件已经存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDSPath.Text = "";
                        txtDSPath.Focus();
                    }
                    else
                    {
                        btnDStore.Enabled = false;
                        btnExit.Enabled = false;
                        eq.excutesql("backup database " + databasename + " to disk='" + txtDSPath.Text.Trim() + "flyauth" + DateTime.Now.ToString("DByyyyMMddhhmmss") + ".bak'");
                        MessageBox.Show("数据备份成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnDStore.Enabled = true;
                        btnExit.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}