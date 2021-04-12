using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge_Data;
using ShopBridge_Data.Interfaces;
using ShopBridge_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_Services.Services
{
  public  class ProductsService : IProducts
    {
        protected readonly ShopBridgeDBContext _context;
        public ProductsService(ShopBridgeDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Products>> Add(Products newProducts)
        {
            _context.Products.Add(newProducts);
            await _context.SaveChangesAsync();  
            return new OkObjectResult(new Products { Prod_Id = newProducts.Prod_Id, Name = newProducts.Name});
        }

        public bool CheckIfProdExist(long ProdId, string strProdName)
        {
            dynamic Products;
            if (ProdId==0)
            {
                Products = _context.Products.AsQueryable().Where(x => x.Name.Trim().ToLower() == strProdName.Trim().ToLower() && x.Is_Deleted != true).ToList();
            }
            else
            {
                Products = _context.Products.AsQueryable().Where(x => x.Prod_Id != ProdId && x.Name.Trim().ToLower() == strProdName.Trim().ToLower() && x.Is_Deleted != true).ToList();  
            }
           

            if(Products.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public async Task<ActionResult<Products>> Delete( Products newProducts)
        {
            _context.Products.Remove(newProducts);
            await _context.SaveChangesAsync(); 
            return new OkObjectResult(new Products { Prod_Id = newProducts.Prod_Id, Name = newProducts.Name });
 
        }

        public async Task<ActionResult<IEnumerable<Products>>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ActionResult<Products>> GetById(long id)
        {
            var Products = await _context.Products.FindAsync(id);

            return Products;
        }

        public async Task<IActionResult> Update(long ProdId, Products newProducts)
        {
            _context.Entry(newProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex )
            {
                throw ex;
            }

            return new OkObjectResult(new Products { Prod_Id = newProducts.Prod_Id, Name = newProducts.Name });
        }



 





    }
}
