using Ozeki.Camera;
using Ozeki.Network;
using SQLite;
using System.Collections.Generic;

public class Devices
{
    [PrimaryKey, AutoIncrement]
  
    public string ID { get; set; }
 
    public string OriginalRtspUri { get; set; }
 
    public string Username { get; set; }

    public string Password { get; set; }

    public TransportType Protocol { get; set; }

    public string SDP { get; set; }
 
    public List<RtspMethod> SupportedMethods { get; set; }

    public override string ToString()
    {
        return string.Format("[Devices: ID={0}, OriginalRtspUri={1}, Username={2}, Password={3}, Protocol={4}, SDP={5}, SupportedMethods={6}]", ID, OriginalRtspUri, Username, Password, Protocol, SDP, SupportedMethods);
    }
}