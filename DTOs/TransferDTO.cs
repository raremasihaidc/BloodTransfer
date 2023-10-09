using System.Text.Json.Serialization;

namespace BloodTransferAPI.DTOs
{
    public class TransferDTO
    {
      [JsonIgnore] public int UserId { get; set; }
        public int RecieverId { get; set; }
        public int TransmiiterId { get; set; }
    }
}
