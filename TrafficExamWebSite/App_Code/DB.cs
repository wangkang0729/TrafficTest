using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

/// <summary>
/// DB 的摘要说明
/// </summary>
public class DB
{
    public DB()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public SqlConnection GetCon()
    {
        return new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
    }

    public int sqlEx(string cmdstr)
    {
        SqlConnection con = GetCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(cmdstr, con);
        try
        {
            cmd.ExecuteNonQuery();
            return 1;
        }
        catch
        {
            return 0;
        }
        finally
        {
            con.Dispose();
        }

    }

    public DataTable reDt(string cmdstr)
    {
        SqlConnection con = GetCon();
        SqlDataAdapter da = new SqlDataAdapter(cmdstr, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return (ds.Tables[0]);
    }

    public SqlDataReader reDr(string str)
    {
        SqlConnection con = GetCon();
        con.Open();
        SqlCommand com = new SqlCommand(str, con);
        SqlDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }

    public int getFristValue(string str)
    {
        SqlConnection con = GetCon();
        con.Open();
        SqlCommand com = new SqlCommand(str, con);
        object obj = com.ExecuteScalar();
        int value = 0;
        if (obj == System.DBNull.Value)
        {
            value = 0;
        }
        else 
        {
            value = Convert.ToInt32(obj);
        }
        con.Close();
        return value;
    }

    public string GetMD5(string strPwd)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.Default.GetBytes(strPwd);
        byte[] md5data = md5.ComputeHash(data);
        md5.Clear();
        string str = "";
        for (int i = 0; i < md5data.Length - 1; i++)
        {
            str += md5data[i].ToString("x").PadLeft(2, '0');
        }
        return str;
    }

    public DataSet reDs(string P_str_cmdtxt)
    {
        SqlConnection con = GetCon();
        SqlDataAdapter da = new SqlDataAdapter(P_str_cmdtxt, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

    public bool ExSql(string P_str_cmdtxt)
    {
        SqlConnection con = GetCon();
        con.Open();
        SqlCommand cmd = new SqlCommand(P_str_cmdtxt, con);
        try
        {
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        finally
        {
            con.Dispose();
        }
    }
}