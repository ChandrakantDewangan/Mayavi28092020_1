using System.Collections.Generic;
using System.Web.Services;
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class UserDetails_ws : System.Web.Services.WebService
{
    DataBaseOperations dbop = new DataBaseOperations();
    public UserDetails_ws()
    {

    }
    [WebMethod]
    public void GetDevices(string DeviceID)
    {
        DEVICES_C devices = dbop.GetDevices(DeviceID);
        if (string.IsNullOrWhiteSpace(devices.DID))
        {
            devices = null;
        }
        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        Context.Response.Write(js.Serialize(devices));
    }
    [WebMethod]
    public void GetDevicesByUserID(string UserID)
    {
        List<DEVICES_C> list = dbop.GetDevicesByUserID(UserID);
        if (list.Count > 0)
        {

        }
        else
        {
            list = null;
        }
        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        Context.Response.Write(js.Serialize(list));
    }
    [WebMethod]
    public int DeleteDevices(string DID)
    {
        return dbop.DeleteDevices(DID);
    }
    [WebMethod]
    public int InsertDevices(string UID, string DEVICE_NAME)
    {
        return dbop.InsertDevices(UID, DEVICE_NAME);
    }
    [WebMethod]
    public int UpdateDevices(string DID, string DEVICE_NAME)
    {
        return dbop.UpdateDevices(DID, DEVICE_NAME);
    }
}
