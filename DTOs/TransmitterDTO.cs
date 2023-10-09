using System.Text.Json.Serialization;

namespace BloodTransferAPI.DTOs
{
    public class TransmitterDTO
    {
       public int UserId { get; set; }
        public int UnitOfBlood { get; set; }
        public int TransmiiterId { get; set; }
        public string FullName { get; set; }
        public int NumberOfTransmitting { get; set; }
        public string BloodGroupType { get; set; }
    }
}
