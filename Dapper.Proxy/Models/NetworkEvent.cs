//using System.ComponentModel.DataAnnotations.Schema;

using System.Diagnostics.CodeAnalysis;

namespace Dapper.Core.Models
{
    //[Table("NetworkEvents")]
    //public class NetworkEvent
    //{
    //    [Column("Id")]
    //    public int Id { get; set; }
    //    [Column("Event_Id")]
    //    public int EventId { get; set; }
    //    [Column("Switch_Ip")]
    //    public string SwitchIp { get; set; }
    //    [Column("Port_Id")]
    //    public int PortId { get; set; }
    //    [Column("Device_Mac")]
    //    public string DeviceMac { get; set; }
    //    [Column("Remarks")]
    //    public string Remarks { get; set; }
    //}


    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NetworkEvent
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Id { get; set; }
        public int Event_Id { get; set; }
        public string Switch_Ip { get; set; }
        public int Port_Id { get; set; }
        public string Device_Mac { get; set; }
        public string Remarks { get; set; }
    }
}