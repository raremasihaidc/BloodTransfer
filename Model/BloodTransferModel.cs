using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodTransferAPI.Model
{
    
    public class BloodTransferModel
    {

        [Key]  public int UserId { get; set; }
        public int UnitOfBlood { get; set; }    
       public string FullName { get; set; }
       public int RecieverId { get; set; }
        public int TransmiiterId { get; set; }
        public string BloodGroupType { get; set; }
        public int NumberOfTransmitting { get; set; }
        public int NumberOfRecieving { get; set; }
    }
}
