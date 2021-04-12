using Microsoft.EntityFrameworkCore;
using ShopBridge_Data.Models;
 

namespace ShopBridge_Data
{
    public class ShopBridgeDBContext : DbContext
    {
        public ShopBridgeDBContext()
        {
        }
        public ShopBridgeDBContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }
    }
}
