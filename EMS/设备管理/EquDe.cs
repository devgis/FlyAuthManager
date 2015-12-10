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

namespace EMS.设备管理
{
    public partial class EquDe : Form
    {
        public string username;
        public int userid;
        exsql eq = new exsql();
        public EquDe()
        {
            InitializeComponent();
        }

        private void EquDe_Load(object sender, EventArgs e)
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == label21.Text)
            {
                MessageBox.Show("重复操作!");
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("请选择处理方式!");

                }
                else
                {
                    if (textBox1.Text != "")
                    {
                        if (label20.Text != "")
                        {
                            string upstr = string.Format("update equipment set state='{0}'", comboBox1.Text);//用于更新设备状态
                            string logstr = string.Format("insert into equiplog(sn,logtype,optime,userid)values('{0}','{1}','{2}',{3})",textBox1.Text,comboBox1.Text,DateTime.Now.ToString("yyyy-MM-dd"),userid);//用于写入日志
                            eq.excutesql(upstr);
                            eq.excutesql(logstr);
                            label21.Text = comboBox1.Text;
                            MessageBox.Show("处理成功!");

                        }

                    }
                    else
                    {
                        MessageBox.Show("请输入设备编码!");
                    }

                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox1.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入数字！");
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
                label20.Text ="";
                label19.Text = "";
                label18.Text = "";
                label17.Text = "";
                label16.Text = "";
                label15.Text = "";
                label14.Text = "";
                label21.Text = "";
            }
        }
    }
}
