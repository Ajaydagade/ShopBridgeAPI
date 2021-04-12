using Microsoft.AspNetCore.Mvc;
using ShopBridge_Data.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridge_Data.Interfaces
{
  public interface IProducts
    {

          Task<ActionResult<IEnumerable<Products>>> GetAll();
        //  List<Products> GetAll();
        Task<ActionResult<Products>> GetById(long id); 
        Task<ActionResult<Products>> Add(Products newProducts);


        bool CheckIfProdExist(long ProdId, string strProdName);
        Task<IActionResult> Update(long ProdId, Products newProducts);

        Task<ActionResult<Products>> Delete(Products  newProducts);
     
        
    }
}
