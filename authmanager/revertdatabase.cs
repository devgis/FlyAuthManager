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
    public partial class revertdatabase : Form
    {
        sysinfo ss = new sysinfo();
        exsql eq = new exsql();
        string databasename;
        public revertdatabase()
        {
            InitializeComponent();
            SqlConnection con = ss.getcon();
            databasename = con.Database;
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "bak files (*.bak)|*.bak";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ShowDialog();
            txtDRPath.Text = openFileDialog1.FileName.ToString().Trim();
        }

        private void btnDRevert_Click(object sender, EventArgs e)
        {
            if (txtDRPath.Text=="")
            {
                MessageBox.Show("请选择数据库备份路径！");
            }
            else
            {
                try
                {
                    btnDRevert.Enabled = false;
                    btnExit.Enabled = false;
                    eq.excutesql("use master restore database "+databasename+" from disk='" + txtDRPath.Text.Trim() + "'");
                    MessageBox.Show("数据还原成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDRevert.Enabled = true;
                    btnExit.Enabled = true;
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