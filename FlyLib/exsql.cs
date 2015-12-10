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
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace flylib
{
    public class exsql
    {
        sysinfo ss = new sysinfo();//初始化系统信息
        SqlConnection con;
        string selstr;
        /*******************************************************************************
         * 执行sql语句不成功
         * *****************************************************************************/
        public int excutesql(string sqlstr)
        {
            con = ss.getcon();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 0;
            }
            catch (SqlException)
            {
                return -1;
            }
        }
        public SqlDataReader excutereader(string sqlstr)
        {
            con = ss.getcon();
            SqlDataReader reader;
            try
            {
                SqlCommand cmd = new  SqlCommand(sqlstr, con);
                con.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return reader;
        }
        public DataSet excuterdataset(string sqlstr)
        {
            con = ss.getcon();
            SqlCommand cmd = new SqlCommand(sqlstr, con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            con.Open();
            cmd.ExecuteNonQuery();
            da.Fill(ds);
            con.Close();
            return ds;
        }
        public int selid(string nodename,int deep) //0返回是否存在authority,否则返回subauthority
        {
            con = ss.getcon();
            int returnid;
            switch (deep)
            {
                case 0:
                    selstr = string.Format("SELECT userid from [user] where username='{0}'",nodename);//查找用户的id
                    break;
                case 1:
                    selstr = string.Format("SELECT roleid from role where role='{0}'", nodename);//查找角色的id
                    break;
                case 2:
                    selstr = string.Format("SELECT authorityid from authority where authority='{0}'", nodename);//查找权限的id
                    break;
                case 3:
                    selstr = string.Format("SELECT subauthorityid from subauthority where subauthority='{0}'", nodename);//查找子权限的id
                    break;
            }
            try
            {
                SqlCommand cmd = new SqlCommand(selstr, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                returnid = Convert.ToInt32(reader[0]);
                con.Close();
                return returnid;
            }
            catch (SqlException)
            {
                return -1;
            }
        }
        public string selname(int nodeid, int deep) //0返回是否存在authority,否则返回subauthority
        {
            con = ss.getcon();
            string returnname;
            switch (deep)
            {
                case 0:
                    selstr = string.Format("SELECT userid from [user] where userid='{0}'", nodeid);//查找用户的id
                    break;
                case 1:
                    selstr = string.Format("SELECT roleid from role where roleid='{0}'", nodeid);//查找角色的id
                    break;
                case 2:
                    selstr = string.Format("SELECT authorityid from authority where authorityid='{0}'", nodeid);//查找权限的id
                    break;
                case 3:
                    selstr = string.Format("SELECT subauthorityid from subauthority where subauthorityid='{0}'", nodeid);//查找子权限的id
                    break;
            }
            try
            {
                SqlCommand cmd = new SqlCommand(selstr, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                returnname = reader[0].ToString();
                con.Close();
                return returnname;
            }
            catch (SqlException)
            {
                return null;
            }
        }
        public int selcount(int uid, int rid, int aid,int sid)
        {
            con = ss.getcon();
            string selstr = string.Format("select count(*) from userper where (userid={0} and roleid={1} and authorityid={2} and subauthorityid={3})", uid, rid, aid,sid);
            SqlCommand cmd = new SqlCommand(selstr, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int recount = Convert.ToInt32(reader[0]);
            con.Close();
            return recount;
        }
        public int selcount(int uid, int rid, int aid)
        {
            con = ss.getcon();
            string selstr = string.Format("select count(*) from userper where (userid={0} and roleid={1} and authorityid={2})", uid, rid, aid);
            SqlCommand cmd = new SqlCommand(selstr, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int recount = Convert.ToInt32(reader[0]);
            con.Close();
            return recount;   
        }
        public int selcount(int uid, int rid)
        {
            con = ss.getcon();
            string selstr = string.Format("select count(*) from userper where (userid={0} and roleid={1} )", uid, rid);
            SqlCommand cmd = new SqlCommand(selstr, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int recount = Convert.ToInt32(reader[0]);
            con.Close();
            return recount;
        }

    }
}
