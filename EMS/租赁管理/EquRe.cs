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

namespace EMS.租赁管理
{
    public partial class EquRe : Form
    {
        public string username;
        public int userid;
        exsql eq = new exsql();
        public EquRe()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDecimal(textBox1.Text.Trim());
            }
            catch (FormatException)
            {
                textBox1.Text = "";
            }
            string sn = textBox1.Text.Trim();
            //string selstr = string.Format("select equipname,typeid,logoid,specid,proddate,departid,other from equipment where sn='{0}'", sn);
            string selstr = string.Format("SELECT equipment.equipname, equiptype.typename,equiprlogo.logoname, equiprspec.specname, equipment.proddate,department.departname, equipment.other,equipment.state,equipment.logid FROM equipment INNER JOIN equiptype ON equipment.typeid = equiptype.typeid INNER JOIN equiprlogo ON equipment.logoid = equiprlogo.logoid INNER JOIN equiprspec ON equipment.specid = equiprspec.specid INNER JOIN department ON equipment.departid = department.departid where sn='{0}'", sn);
            SqlDataReader reader = eq.excutereader(selstr);
            reader.Read();
            try
            {
                Convert.ToString(reader[0]);
                label20.Text = reader[0].ToString();
                label19.Text = reader[1].ToString();
                label18.Text = reader[2].ToString();
                label17.Text = reader[3].ToString();
                label16.Text = Convert.ToDateTime(reader[4]).ToString("yyyy-MM-dd");
                label15.Text = reader[5].ToString();
                label14.Text = reader[6].ToString();
                //赋值
            }
            catch (InvalidOperationException)
            {
                //数据为空时不做任何处理
                label20.Text = "";
                label19.Text = "";
                label18.Text = "";
                label17.Text = "";
                label16.Text = "";
                label15.Text = "";
                label14.Text = "";
            }
        }

        private void EquRe_Load(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label5.Text = username;

            label20.Text = "";
            label19.Text = "";
            label18.Text = "";
            label17.Text = "";
            label16.Text = "";
            label15.Text = "";
            label14.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //用于判断设备状态
            string sn = textBox1.Text.Trim();
            //string selstr = string.Format("select equipname,typeid,logoid,specid,proddate,departid,other from equipment where sn='{0}'", sn);
            string selstr = string.Format("SELECT equipment.equipname, equiptype.typename,equiprlogo.logoname, equiprspec.specname, equipment.proddate,department.departname, equipment.other,equipment.state,equipment.logid FROM equipment INNER JOIN equiptype ON equipment.typeid = equiptype.typeid INNER JOIN equiprlogo ON equipment.logoid = equiprlogo.logoid INNER JOIN equiprspec ON equipment.specid = equiprspec.specid INNER JOIN department ON equipment.departid = department.departid where sn='{0}'", sn);
            SqlDataReader reader = eq.excutereader(selstr);
            reader.Read();

            if (textBox1.Text =="" || label20.Text == "")
            {
                MessageBox.Show("请输入设备编码！");
            }
            else
            {
                if (reader[8].ToString() == "")
                {
                    MessageBox.Show("设备未租出，无须归还！");
                }
                else
                {
                    //归还操作
                    string upstr = string.Format("update equipment set logid=null where sn='{0}'", textBox1.Text);
                    eq.excutesql(upstr);
                    
                    //写日志
                    string logstr = string.Format("update lendlog set returndate='{0}',returnUserid={1} where logid={2}", DateTime.Now.ToString("yyyy-MM-dd"),userid, Convert.ToInt32(reader[8].ToString()));
                    eq.excutesql(logstr);
                    MessageBox.Show("归还成功！");
                }
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
