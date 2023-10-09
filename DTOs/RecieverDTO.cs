using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BloodTransferAPI.DTOs
{
    public class RecieverDTO
    {
        public int UserId { get; set; }
        public int UnitOfBlood { get; set; }
        public string FullName { get; set; }
         public int RecieverId { get; set; }
        public int NumberOfRecieving { get; set; }
        public string BloodGroupType { get; set; }
    }
}
