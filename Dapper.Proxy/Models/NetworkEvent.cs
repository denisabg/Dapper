namespace Dapper.Proxy.Models
{
    public class NetworkEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        
        public string SwitchIp { get; set; }
        public int PortId { get; set; }
        
        public string DeviceMac { get; set; }

        public string Remarks { get; set; }
    }
}
