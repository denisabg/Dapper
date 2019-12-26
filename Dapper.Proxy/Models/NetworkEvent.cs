namespace Dapper.Proxy.Models
{
    public class NetworkEvent
    {
        public int Id { get; set; }
        public int Event_Id { get; set; }
        
        public string Switch_Ip { get; set; }
        public int Port_Id { get; set; }
        
        public string Device_Mac { get; set; }

        public string Remarks { get; set; }
    }
}
