using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
namespace ShopBridge_Data.Models
{
    [Table("tbl_Products")]
    public class Products
    {

        [Key]
        [Column(TypeName = "bigint")]
        public long Prod_Id { get; set; }

        public string Name   { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long Qty { get; set; }
        public DateTime? Mf_Date
        { get; set; }
        public DateTime? Ex_date
        { get; set; }


        public bool? Is_Edited { get; set; }

        public bool? Is_Deleted { get; set; }

     
        public int? Inserted_User_ID
        { get; set; }

        public DateTime? Inserted_Date
        { get; set; }

       

        public int? Updated_User_ID
        { get; set; }

        public DateTime? Updated_Date
        { get; set; }
    }
}
