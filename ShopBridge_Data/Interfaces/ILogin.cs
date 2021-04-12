using Microsoft.AspNetCore.Mvc;
using ShopBridge_Data.Models;
using System.Threading.Tasks;

namespace ShopBridge_Data.Interfaces
{
    public interface IEmployee
    {
        Task<bool> GetById(string strEmail, string strPassword);
    }
}
