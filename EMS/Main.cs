using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using flylib;

namespace EMS
{
    public partial class Main : Form
    {
        public string username;
        public int userid;
        percheck pck = new percheck();
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = this.username;  //系统用户
            toolStripStatusLabel4.Text = DateTime.Now.ToString("yyyy-MM-dd");  //系统日期

            timer1.Enabled = true;
            timer1.Interval = 1000;

            //查询USERID
            string selstr = string.Format("select userid from [user] where username='{0}'", username);
            exsql eq = new exsql();
            SqlDataReader reader = eq.excutereader(selstr);
            reader.Read();
            userid = Convert.ToInt32(reader[0]);

        }

        private void 重新登陆CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
            this.Dispose();
        }

        private void 退出系统TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void 权限管理QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 1, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }else
            {
                authmanager.main mn = new authmanager.main();
                mn.Show();
            }
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 2, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                ChgPwd cp = new ChgPwd();
                cp.Show();
            }
        }

        private void 录入设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 3, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                设备管理.EquIn EI = new EMS.设备管理.EquIn();
                EI.userid = userid;
                EI.username = username;
                EI.Show();
            }
        }

        private void 编辑设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 4, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                设备管理.EquEd EE = new EMS.设备管理.EquEd();
                EE.userid = userid;
                EE.username = username;
                EE.Show();
            }
        }

        private void 设备处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 5, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                设备管理.EquDe ED = new EMS.设备管理.EquDe();
                ED.userid = userid;
                ED.username = username;
                ED.Show();
            }
        }

        private void 设备查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            if (pck.check(username, 6, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                设备管理.EquSe ES = new EMS.设备管理.EquSe();
                ES.Show();
            }
        }

        private void 处理日志LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 7, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                设备管理.DeLog DL = new EMS.设备管理.DeLog();
                DL.Show();
            }
        }

        private void 人员录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 8, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                人员管理.PerIn PI = new EMS.人员管理.PerIn();
                PI.userid = userid;
                PI.username = username;
                PI.Show();
            }
        }

        private void 人员编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 9, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                人员管理.PerEd PE = new EMS.人员管理.PerEd();
                PE.userid = userid;
                PE.username = username;
                PE.Show();
            }
        }

        private void 人员查找SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username,10, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                人员管理.PerSe PS = new EMS.人员管理.PerSe();
                PS.Show();
            }
        }

        private void 设备租赁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 11, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                租赁管理.EquLe EL = new EMS.租赁管理.EquLe();
                EL.userid = userid;
                EL.username = username;
                EL.Show();
            }
        }

        private void 设备归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 12, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                租赁管理.EquRe ER = new EMS.租赁管理.EquRe();
                ER.userid = userid;
                ER.username = username;
                ER.Show();
            } 
        }

        private void 状态查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 13, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                租赁管理.EquSt ES = new EMS.租赁管理.EquSt();
                ES.Show();
            }
        }

        private void 日志查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 14, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                租赁管理.EquLog EL = new EMS.租赁管理.EquLog();
                EL.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 15, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                基础资料.BasDep BD = new EMS.基础资料.BasDep();
                BD.Show();
            }
        }

        private void 设备类别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 16, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                基础资料.EquTyp ET = new EMS.基础资料.EquTyp();
                ET.Show();
            }
        }

        private void 设备品牌ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 17, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                基础资料.EquLog EL = new EMS.基础资料.EquLog();
                EL.Show();
            }
        }

        private void 规格型号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 18, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                基础资料.EquSpc ES = new EMS.基础资料.EquSpc();
                ES.Show();
            }
        }

        private void 使用属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 19, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                基础资料.EquUse EU = new EMS.基础资料.EquUse();
                EU.Show();
            }
        }

        private void 帮助HToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help hp = new Help();
            hp.Show();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel6.Text = DateTime.Now.ToString("hh:mm:ss");  //系统时间
        }
        private void 固定资产使用登记簿GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 20, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                报表管理.固定资产使用登记报表 greport = new EMS.报表管理.固定资产使用登记报表();
                greport.Show();
            }
        }

        private void 清查明细表QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pck.check(username, 21, 0) != 1)
            {
                MessageBox.Show("没有该权限，请与您的管理员联系！");
            }
            else
            {
                报表管理.清查明细表 qreport = new EMS.报表管理.清查明细表();
                qreport.Show();
            }
        }
    }
}