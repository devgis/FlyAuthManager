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
    public partial class EquSt : Form
    {
        public EquSt()
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
    }
}
