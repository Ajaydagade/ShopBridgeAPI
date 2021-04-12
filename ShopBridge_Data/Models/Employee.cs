using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  
namespace ShopBridge_Data.Models
{
    [Table("tbl_Employee")]
    public class Employee
    {
        [Key]
        [Column(TypeName = "bigint")]
        public long Employee_ID { get; set; }

        public string Employee_Name { get; set; }
        public string Email { get; set; }

        public string Employee_Password { get; set; }
         
    }
}
