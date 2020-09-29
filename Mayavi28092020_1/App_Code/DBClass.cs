using System.Collections.Generic;

public class MAYAVI_USERS_C
{
    public string UID { get; set; }
    public string USER_NAME { get; set; }
    public string EMAIL { get; set; }
    public string MOBILENO { get; set; }
    public string ORGANIZATION { get; set; }
    public string PWD { get; set; }
    public string PRIVILEGE { get; set; }
    public List<DEVICES_C> DEVICES { get; set; }
}
public class DEVICES_C
{
    public string DID { get; set; }
    public string UID { get; set; }
    public string DEVICE_NAME { get; set; }
    public string HOST_NAME { get; set; }
    public string DEVICE_ID { get; set; }
    public string DEVICE_KYE { get; set; }
    public string CONNECTION_STATUS { get; set; }
    public string TXRX_LIMIT { get; set; }
    public string BANDWIDTH { get; set; }
    public string UPTIME { get; set; }
    public string USER_NAME { get; set; }
}