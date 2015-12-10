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
    public class percheck
    {
        exsql eq = new exsql();
        string sqlcheckstr;

        public int check(string username,int id,int deep)
        {
            int uid = eq.selid(username, 0);
            int resultno;
            if (deep==0) //权限检查
            {
                sqlcheckstr = string.Format("select count(*) from userper where(userid={0} and authorityid={1})",uid,id);
            }
            else
            {
                if (deep == 1)
                {
                    sqlcheckstr = string.Format("select count(*) from userper where(userid={0} and subauthorityid={1})", uid, id);
                }
                else
                {
                    sqlcheckstr = string.Format("select count(*) from userper where (userid={0} and roleid={1})", uid, id);
                }
            }

            SqlDataReader reader = eq.excutereader(sqlcheckstr);
            reader.Read();
            resultno = Convert.ToInt32(reader[0]);
            reader.Close();

            if (resultno > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int usercheck(string username,string userpassword)
        {
            /**********************************************************************
             * 检验用户名密码以及用户状态
             * 0,密码正确状态正常，1，用户名为空，2，密码为空，
             * 3，数据库异常或者记录不存在，
             * 4，密码错误，5，用户被禁用
             * ********************************************************************/

            if (username == "")
            {
                return 1; //用户名为空
            }
            else
            {
                if (userpassword == "")
                {
                    return 2; //密码为空
                }
                else
                {
                    string selstr=string.Format("select userpassword from [user] where username='{0}'",username);//查询用户密码语句
                    string selstr1 = string.Format("select userstate from [user] where username='{0}'",username);//查询用户状态语句
                    SqlDataReader reader = eq.excutereader(selstr);
                    if (reader.Read())//如果存在该用户名的记录
                    {
                        if (reader[0].ToString() == userpassword) //密码正确
                        {
                            reader.Close();
                            SqlDataReader reader1=eq.excutereader(selstr1);
                            if(reader1.Read())
                            {
                                if (Convert.ToInt32(reader1[0]) == 1)
                                {
                                    reader1.Close();
                                    return 0;
                                }
                                else
                                {
                                    reader1.Close();
                                    return 5;    //用户被禁用
                                }
                            }
                            else
                            {
                                return 3; //数据库异常,记录不存在显示提示语
                            }
                        }
                        else　　
                        {
                            reader.Close();
                            return 4; //密码错误，显示提示语
                        }
                    }
                    else　　
                    {
                        reader.Close();
                        return 3; //数据库异常,记录不存在显示提示语
                    }          
                }
            }
        }
    }
}
