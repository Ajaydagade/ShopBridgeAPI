using Microsoft.AspNetCore.Mvc;
using ShopBridge_Data;
using ShopBridge_Data.Interfaces;
using ShopBridge_Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_Services.Services
{
    public class EmployeeService : IEmployee
    {
        protected readonly ShopBridgeDBContext _context;

        public EmployeeService(ShopBridgeDBContext context)
        {
            _context = context;
        } 
        public async Task<bool> GetById(string strEmail, string strPassword)
        {
            var Employee = _context.Employee.AsQueryable().Where(x => x.Email.Trim().ToLower() == strEmail.Trim().ToLower() && x.Employee_Password.Trim().ToLower() == strPassword.Trim().ToLower()).ToList();

            if (Employee.Count > 0)
            {
                return   true;
            }
            else
            {
                return   false;
            }
        }
    }
}
