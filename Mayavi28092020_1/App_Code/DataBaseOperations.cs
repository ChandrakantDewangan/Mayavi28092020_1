using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

public class DataBaseOperations
{
    string Query = string.Empty;
    DataBaseConnection db = new DataBaseConnection();
    public int InsertMayavi_Users(string USER_NAME, string EMAIL, string PWD)
    {
        int AffectedRow = 0;
        try
        {
            string MOBILENO = "";
            string ORGANIZATION = "";
            string PRIVILEGE = "F";
            MD5Encryption md5 = new MD5Encryption();
            PWD = md5.Encryption(PWD);
            Query = @"INSERT INTO MAYAVI_USERS(USER_NAME,EMAIL,MOBILENO,ORGANIZATION,PWD,PRIVILEGE) VALUES(@USER_NAME,@EMAIL,@MOBILENO,@ORGANIZATION,@PWD,@PRIVILEGE)";
            AffectedRow = db.ExecuteInsert(Query,
                new MySqlParameter("@USER_NAME", USER_NAME),
                new MySqlParameter("@EMAIL", EMAIL),
                new MySqlParameter("@MOBILENO", MOBILENO),
                new MySqlParameter("@ORGANIZATION", ORGANIZATION),
                new MySqlParameter("@PWD", PWD),
                new MySqlParameter("@PRIVILEGE", PRIVILEGE));
        }
        catch
        {
            AffectedRow = 0;
        }
        return AffectedRow;
    }
    public int UpdateMayavi_Users(string USER_NAME, string EMAIL, string MOBILENO, string ORGANIZATION, string PWD, string PRIVILEGE, string UID)
    {
        int AffectedRow = 0;
        try
        {
            MD5Encryption md5 = new MD5Encryption();
            PWD = md5.Encryption(PWD);
            Query = @"UPDATE MAYAVI_USERS SET USER_NAME=@USER_NAME,EMAIL=@EMAIL,MOBILENO=@MOBILENO,ORGANIZATION=@ORGANIZATION,PWD=@PWD,PRIVILEGE=@PRIVILEGE WHERE UID=@UID";
            AffectedRow = db.ExecuteUpdate(Query,
                new MySqlParameter("@USER_NAME", USER_NAME),
                new MySqlParameter("@EMAIL", EMAIL),
                new MySqlParameter("@MOBILENO", MOBILENO),
                new MySqlParameter("@ORGANIZATION", ORGANIZATION),
                new MySqlParameter("@PWD", PWD),
                new MySqlParameter("@PRIVILEGE", PRIVILEGE),
                new MySqlParameter("@UID", UID));
        }
        catch
        {
            AffectedRow = 0;
        }
        return AffectedRow;
    }
    public int DeleteMayavi_Users(string UID)
    {
        int AffectedRow = 0;
        try
        {
            Query = "DELETE FROM MAYAVI_USERS WHERE UID=@UID";
            AffectedRow = db.ExecuteInsert(Query, new MySqlParameter("UID", UID));
        }
        catch
        {
            AffectedRow = 0;
        }
        return AffectedRow;
    }
    public MAYAVI_USERS_C GetMayaviUser(string UserID)
    {
        MAYAVI_USERS_C mayavi_users_details = new MAYAVI_USERS_C();
        Query = @"SELECT UID,USER_NAME,EMAIL,MOBILENO,ORGANIZATION,PWD,PRIVILEGE FROM MAYAVI_USERS WHERE UID=@UID";
        DataTable DataTable_MAYAVI_USERS = db.ExecuteSelect(Query, new MySqlParameter("@UID", UserID));
        if (DataTable_MAYAVI_USERS.Rows.Count > 0)
        {
            foreach (DataRow item in DataTable_MAYAVI_USERS.Rows)
            {
                mayavi_users_details.UID = item["UID"].ToString();
                mayavi_users_details.USER_NAME = item["USER_NAME"].ToString();
                mayavi_users_details.EMAIL = item["EMAIL"].ToString();
                mayavi_users_details.MOBILENO = item["MOBILENO"].ToString();
                mayavi_users_details.ORGANIZATION = item["ORGANIZATION"].ToString();
                mayavi_users_details.PWD = item["PWD"].ToString();
                mayavi_users_details.PRIVILEGE = item["PRIVILEGE"].ToString();
            }
        }
        return mayavi_users_details;
    }
    public MAYAVI_USERS_C GetMayaviUserByMail(string EMAIL)
    {
        MAYAVI_USERS_C mayavi_users_details = new MAYAVI_USERS_C();
        Query = @"SELECT UID,USER_NAME,EMAIL,MOBILENO,ORGANIZATION,PWD,PRIVILEGE FROM MAYAVI_USERS WHERE EMAIL=@EMAIL";
        DataTable DataTable_MAYAVI_USERS = db.ExecuteSelect(Query, new MySqlParameter("@EMAIL", EMAIL));
        if (DataTable_MAYAVI_USERS.Rows.Count > 0)
        {
            foreach (DataRow item in DataTable_MAYAVI_USERS.Rows)
            {
                mayavi_users_details.UID = item["UID"].ToString();
                mayavi_users_details.USER_NAME = item["USER_NAME"].ToString();
                mayavi_users_details.EMAIL = item["EMAIL"].ToString();
                mayavi_users_details.MOBILENO = item["MOBILENO"].ToString();
                mayavi_users_details.ORGANIZATION = item["ORGANIZATION"].ToString();
                mayavi_users_details.PWD = item["PWD"].ToString();
                mayavi_users_details.PRIVILEGE = item["PRIVILEGE"].ToString();
            }
        }
        return mayavi_users_details;
    }
    public MAYAVI_USERS_C GetMayaviUserByMailPwd(string EMAIL, string PWD)
    {
        bool IsValid = false;
        MD5Encryption md5 = new MD5Encryption();
        PWD = md5.Encryption(PWD);
        MAYAVI_USERS_C mayavi_users_details = new MAYAVI_USERS_C();
        Query = @"SELECT UID,USER_NAME,EMAIL,MOBILENO,ORGANIZATION,PWD,PRIVILEGE FROM MAYAVI_USERS WHERE EMAIL=@EMAIL AND PWD=@PWD";
        DataTable DataTable_MAYAVI_USERS = db.ExecuteSelect(Query, new MySqlParameter("@EMAIL", EMAIL), new MySqlParameter("@PWD", PWD));
        if (DataTable_MAYAVI_USERS.Rows.Count > 0)
        {
            foreach (DataRow item in DataTable_MAYAVI_USERS.Rows)
            {
                mayavi_users_details.UID = item["UID"].ToString();
                mayavi_users_details.USER_NAME = item["USER_NAME"].ToString();
                mayavi_users_details.EMAIL = item["EMAIL"].ToString();
                mayavi_users_details.MOBILENO = item["MOBILENO"].ToString();
                mayavi_users_details.ORGANIZATION = item["ORGANIZATION"].ToString();
                mayavi_users_details.PWD = item["PWD"].ToString();
                mayavi_users_details.PRIVILEGE = item["PRIVILEGE"].ToString();
                IsValid = true;
            }
        }
        return mayavi_users_details;
    }
    public List<MAYAVI_USERS_C> GetAllMayaviUser()
    {
        List<MAYAVI_USERS_C> list_mayavi_users_details = new List<MAYAVI_USERS_C>();
        Query = @"SELECT UID,USER_NAME,EMAIL,MOBILENO,ORGANIZATION,PWD,PRIVILEGE FROM MAYAVI_USERS";
        DataTable DataTable_MAYAVI_USERS = db.ExecuteSelect(Query);
        if (DataTable_MAYAVI_USERS.Rows.Count > 0)
        {
            foreach (DataRow item in DataTable_MAYAVI_USERS.Rows)
            {
                MAYAVI_USERS_C mayavi_users_details = new MAYAVI_USERS_C();
                mayavi_users_details.UID = item["UID"].ToString();
                mayavi_users_details.USER_NAME = item["USER_NAME"].ToString();
                mayavi_users_details.EMAIL = item["EMAIL"].ToString();
                mayavi_users_details.MOBILENO = item["MOBILENO"].ToString();
                mayavi_users_details.ORGANIZATION = item["ORGANIZATION"].ToString();
                mayavi_users_details.PWD = item["PWD"].ToString();
                mayavi_users_details.PRIVILEGE = item["PRIVILEGE"].ToString();
                list_mayavi_users_details.Add(mayavi_users_details);
            }
        }
        return list_mayavi_users_details;
    }
    public int InsertDevices(string UID, string DEVICE_NAME, string HOST_NAME)
    {
        int AffectedRow = 0;
        try
        {
            string DEVICE_ID = null;
            MD5Encryption md5 = new MD5Encryption();
            string DEVICE_KYE = md5.Encryption(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            string CONNECTION_STATUS = "N";
            string TXRX_LIMIT = "0";
            string BANDWIDTH = "100";
            string USER_NAME = "";
            Query = @"INSERT INTO DEVICES(UID,DEVICE_NAME,HOST_NAME,DEVICE_ID,DEVICE_KYE,CONNECTION_STATUS,TXRX_LIMIT,BANDWIDTH,UPTIME,USER_NAME) VALUES(@UID,@DEVICE_NAME,@HOST_NAME,@DEVICE_ID,@DEVICE_KYE,@CONNECTION_STATUS,@TXRX_LIMIT,@BANDWIDTH,NOW(),@USER_NAME)";
            AffectedRow = db.ExecuteInsert(Query,
                new MySqlParameter("@UID", UID),
                new MySqlParameter("@DEVICE_NAME", DEVICE_NAME),
                new MySqlParameter("@HOST_NAME", HOST_NAME),
                new MySqlParameter("@DEVICE_ID", DEVICE_ID),
                new MySqlParameter("@DEVICE_KYE", DEVICE_KYE),
                new MySqlParameter("@CONNECTION_STATUS", CONNECTION_STATUS),
                new MySqlParameter("@TXRX_LIMIT", TXRX_LIMIT),
                new MySqlParameter("@BANDWIDTH", BANDWIDTH),
                new MySqlParameter("@USER_NAME", USER_NAME));
        }
        catch
        {
            AffectedRow = 0;
        }
        return AffectedRow;
    }
    public int InsertDevices(string UID, string DEVICE_NAME)
    {
        int AffectedRow = 0;
        try
        {
            string DEVICE_ID = null;
            string HOST_NAME = string.Empty;
            MD5Encryption md5 = new MD5Encryption();
            string DEVICE_KYE = md5.Encryption(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            string CONNECTION_STATUS = "N";
            string TXRX_LIMIT = "0";
            string BANDWIDTH = "100";
            string USER_NAME = "";
            Query = @"INSERT INTO DEVICES(UID,DEVICE_NAME,HOST_NAME,DEVICE_ID,DEVICE_KYE,CONNECTION_STATUS,TXRX_LIMIT,BANDWIDTH,UPTIME,USER_NAME) VALUES(@UID,@DEVICE_NAME,@HOST_NAME,@DEVICE_ID,@DEVICE_KYE,@CONNECTION_STATUS,@TXRX_LIMIT,@BANDWIDTH,NOW(),@USER_NAME)";
            AffectedRow = db.ExecuteInsert(Query,
                new MySqlParameter("@UID", UID),
                new MySqlParameter("@DEVICE_NAME", DEVICE_NAME),
                new MySqlParameter("@HOST_NAME", HOST_NAME),
                new MySqlParameter("@DEVICE_ID", DEVICE_ID),
                new MySqlParameter("@DEVICE_KYE", DEVICE_KYE),
                new MySqlParameter("@CONNECTION_STATUS", CONNECTION_STATUS),
                new MySqlParameter("@TXRX_LIMIT", TXRX_LIMIT),
                new MySqlParameter("@BANDWIDTH", BANDWIDTH),
                new MySqlParameter("@USER_NAME", USER_NAME));
        }
        catch
        {
            AffectedRow = 0;
        }
        return AffectedRow;
    }
    public int UpdateDevices(string UID, string DEVICE_NAME, string HOST_NAME, string DEVICE_ID, string DEVICE_KYE, string CONNECTION_STATUS, string TXRX_LIMIT, string BANDWIDTH, string UPTIME, string USER_NAME, string DID)
    {
        int AffectedRow = 0;
        try
        {
            Query = @"UPDATE DEVICES SET UID=@UID,DEVICE_NAME=@DEVICE_NAME,HOST_NAME=@HOST_NAME,DEVICE_ID=@DEVICE_ID,DEVICE_KYE=@DEVICE_KYE,CONNECTION_STATUS=@CONNECTION_STATUS,TXRX_LIMIT=@TXRX_LIMIT,BANDWIDTH=@BANDWIDTH,UPTIME=NOW(),USER_NAME=@USER_NAME WHERE DID=@DID";
            AffectedRow = db.ExecuteUpdate(Query,
                new MySqlParameter("@UID", UID),
                new MySqlParameter("@DEVICE_NAME", DEVICE_NAME),
                new MySqlParameter("@HOST_NAME", HOST_NAME),
                new MySqlParameter("@DEVICE_ID", DEVICE_ID),
                new MySqlParameter("@DEVICE_KYE", DEVICE_KYE),
                new MySqlParameter("@CONNECTION_STATUS", CONNECTION_STATUS),
                new MySqlParameter("@TXRX_LIMIT", TXRX_LIMIT),
                new MySqlParameter("@BANDWIDTH", BANDWIDTH),
                new MySqlParameter("@USER_NAME", USER_NAME),
                new MySqlParameter("@DID", DID));
        }
        catch
        {
            AffectedRow = 0;
        }
        return AffectedRow;
    }
    public int UpdateDevices(string DID, string DEVICE_NAME)
    {
        int AffectedRow = 0;
        try
        {
            Query = @"UPDATE DEVICES SET DEVICE_NAME=@DEVICE_NAME WHERE DID=@DID";
            AffectedRow = db.ExecuteUpdate(Query,
                new MySqlParameter("@DEVICE_NAME", DEVICE_NAME),
                new MySqlParameter("@DID", DID));
        }
        catch
        {
            AffectedRow = 0;
        }
        return AffectedRow;
    }
    public int DeleteDevices(string DID)
    {
        int AffectedRow = 0;
        try
        {
            Query = "DELETE FROM DEVICES WHERE DID=@DID";
            AffectedRow = db.ExecuteInsert(Query, new MySqlParameter("DID", DID));
        }
        catch
        {
            AffectedRow = 0;
        }
        return AffectedRow;
    }
    public DEVICES_C GetDevices(string DeviceID)
    {
        DEVICES_C devices_details = new DEVICES_C();
        Query = @"SELECT DID,UID,DEVICE_NAME,HOST_NAME,DEVICE_ID,DEVICE_KYE,CONNECTION_STATUS,TXRX_LIMIT,BANDWIDTH,DATE_FORMAT(UPTIME,'%d/%m/%Y') AS UPTIME,USER_NAME FROM DEVICES WHERE DID=@DID";
        DataTable DataTable_DEVICES = db.ExecuteSelect(Query, new MySqlParameter("@DID", DeviceID));
        if (DataTable_DEVICES.Rows.Count > 0)
        {
            foreach (DataRow item in DataTable_DEVICES.Rows)
            {
                devices_details.DID = item["DID"].ToString();
                devices_details.UID = item["UID"].ToString();
                devices_details.DEVICE_NAME = item["DEVICE_NAME"].ToString();
                devices_details.HOST_NAME = item["HOST_NAME"].ToString();
                devices_details.DEVICE_ID = item["DEVICE_ID"].ToString();
                devices_details.DEVICE_KYE = item["DEVICE_KYE"].ToString();
                devices_details.CONNECTION_STATUS = item["CONNECTION_STATUS"].ToString();
                devices_details.TXRX_LIMIT = item["TXRX_LIMIT"].ToString();
                devices_details.BANDWIDTH = item["BANDWIDTH"].ToString();
                devices_details.UPTIME = item["UPTIME"].ToString();
                devices_details.USER_NAME = item["USER_NAME"].ToString();
            }
        }
        return devices_details;
    }
    public List<DEVICES_C> GetDevicesByUserID(string UserID)
    {
        List<DEVICES_C> list_devices_details = new List<DEVICES_C>();
        Query = @"SELECT DID,UID,DEVICE_NAME,HOST_NAME,DEVICE_ID,DEVICE_KYE,CONNECTION_STATUS,TXRX_LIMIT,BANDWIDTH,DATE_FORMAT(UPTIME,'%d/%m/%Y') AS UPTIME,USER_NAME FROM DEVICES WHERE UID=@UID";
        DataTable DataTable_DEVICES = db.ExecuteSelect(Query, new MySqlParameter("@UID", UserID));
        if (DataTable_DEVICES.Rows.Count > 0)
        {
            foreach (DataRow item in DataTable_DEVICES.Rows)
            {
                DEVICES_C devices_details = new DEVICES_C();
                devices_details.DID = item["DID"].ToString();
                devices_details.UID = item["UID"].ToString();
                devices_details.DEVICE_NAME = item["DEVICE_NAME"].ToString();
                devices_details.HOST_NAME = item["HOST_NAME"].ToString();
                devices_details.DEVICE_ID = item["DEVICE_ID"].ToString();
                devices_details.DEVICE_KYE = item["DEVICE_KYE"].ToString();
                devices_details.CONNECTION_STATUS = item["CONNECTION_STATUS"].ToString();
                devices_details.TXRX_LIMIT = item["TXRX_LIMIT"].ToString();
                devices_details.BANDWIDTH = item["BANDWIDTH"].ToString();
                devices_details.UPTIME = item["UPTIME"].ToString();
                devices_details.USER_NAME = item["USER_NAME"].ToString();
                list_devices_details.Add(devices_details);
            }
        }
        return list_devices_details;
    }
    public List<DEVICES_C> GetAllDevices()
    {
        List<DEVICES_C> list_devices_details = new List<DEVICES_C>();
        Query = @"SELECT DID,UID,DEVICE_NAME,HOST_NAME,DEVICE_ID,DEVICE_KYE,CONNECTION_STATUS,TXRX_LIMIT,BANDWIDTH,DATE_FORMAT(UPTIME,'%d/%m/%Y') AS UPTIME,USER_NAME FROM DEVICES";
        DataTable DataTable_DEVICES = db.ExecuteSelect(Query);
        if (DataTable_DEVICES.Rows.Count > 0)
        {
            foreach (DataRow item in DataTable_DEVICES.Rows)
            {
                DEVICES_C devices_details = new DEVICES_C();
                devices_details.DID = item["DID"].ToString();
                devices_details.UID = item["UID"].ToString();
                devices_details.DEVICE_NAME = item["DEVICE_NAME"].ToString();
                devices_details.HOST_NAME = item["HOST_NAME"].ToString();
                devices_details.DEVICE_ID = item["DEVICE_ID"].ToString();
                devices_details.DEVICE_KYE = item["DEVICE_KYE"].ToString();
                devices_details.CONNECTION_STATUS = item["CONNECTION_STATUS"].ToString();
                devices_details.TXRX_LIMIT = item["TXRX_LIMIT"].ToString();
                devices_details.BANDWIDTH = item["BANDWIDTH"].ToString();
                devices_details.UPTIME = item["UPTIME"].ToString();
                devices_details.USER_NAME = item["USER_NAME"].ToString();
                list_devices_details.Add(devices_details);
            }
        }
        return list_devices_details;
    }
}