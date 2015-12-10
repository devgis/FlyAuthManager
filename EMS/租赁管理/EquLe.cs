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
    public partial class EquLe : Form
    {
        public string username;
        public int userid;
        public EquLe()
        {
            InitializeComponent();
        }

        private void EquLe_Load(object sender, EventArgs e)
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
            label21.Text = "";

            label31.Text = "";
            label29.Text = "";
            label28.Text = "";
            label27.Text = "";
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
            exsql eq = new exsql();
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
                if (reader[7].ToString() == "正常")
                {
                    if (reader[8].ToString().Trim() != "")
                    {
                        label21.Text = "租出";
                    }
                    else
                    {
                        label21.Text = reader[7].ToString();
                    }
                }

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
                label21.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sn = Convert.ToInt32(textBox1.Text.Trim());
            string lenddate = DateTime.Now.ToString("yyyy-MM-dd");
            int personid = Convert.ToInt32(textBox2.Text.Trim());

            if (textBox1.Text == "" || label20.Text == "")
            {
                MessageBox.Show("请设备设备！");
            }
            else
            {
                if (textBox2.Text == "" || label31.Text == "")
                {
                    MessageBox.Show("请选择人员！");
                }
                else
                {
                    exsql eq = new exsql();
                    try
                    {
                        string checkstr = string.Format("select logid from equipment where sn={0}", sn);
                        SqlDataReader reader = eq.excutereader(checkstr);
                        reader.Read();
                        Convert.ToInt32(reader[0]);
                        MessageBox.Show("该设备已经租出！");
                    }
                    catch (InvalidCastException)
                    {
                        //写日志
                        string logstr = string.Format("insert into lendlgo(sn,lenddate,personid,lendUserid)values({0},'{1}',{2},{3})", sn, lenddate, personid,userid);
                        eq.excutesql(logstr);

                        //读log编码
                        string selstr = "SELECT MAX (logid) FROM lendlog";
                        SqlDataReader reader2 = eq.excutereader(selstr);
                        reader2.Read();
                        int logid = Convert.ToInt32(reader2[0]);

                        string upstr = string.Format("Update equipment set logid={0} where sn={1}", sn, logid);
                        eq.excutesql(upstr);

                        MessageBox.Show("租赁成功！");
                    }
                    

                    
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDecimal(textBox2.Text.Trim());
            }
            catch (FormatException)
            {
                textBox2.Text = "";
            }
            exsql eq = new exsql();
            string NO = textBox2.Text.Trim();
            string selstr = string.Format("SELECT person.personname, department.departname, person.position, person.other FROM person INNER JOIN department ON person.departid = department.departid WHERE (person.NO = {0})", NO);
            SqlDataReader reader = eq.excutereader(selstr);
            reader.Read();
            try
            {
                Convert.ToString(reader[0]);
                label31.Text = reader[0].ToString();
                label29.Text = reader[1].ToString();
                label28.Text = reader[2].ToString();
                label27.Text = reader[3].ToString();
            }
            catch (InvalidOperationException)
            {
                //数据为空时不做任何处理
                label31.Text = "";
                label29.Text = "";
                label28.Text = "";
                label27.Text = "";
            }
        }
    }
}
