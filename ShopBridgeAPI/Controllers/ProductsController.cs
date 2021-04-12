using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using ShopBridge_Data.Interfaces;
using ShopBridge_Data.Models; 
using System.Collections.Generic; 
using System.Threading.Tasks;
namespace ShopBridgeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Variable Declaration
        IProducts _iproducts;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="products"></param>
        /// 
        #endregion
        public ProductsController(IProducts products)
        {
            _iproducts = products;
        }
        #region Methods

        /// <summary>
        /// Method is used to return all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAll()
        {   
            return await _iproducts.GetAll(); 
        }

        /// <summary>
        ///  Method is used to return   product based on product id
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        [HttpGet("{ProductID}")]
        public async Task<ActionResult<Products>> GetByProductId(long ProductID)
        { 
            return await _iproducts.GetById(ProductID);
        }

        /// <summary>
        /// Method is used to return  product based on product id and name for remote validation
        /// </summary>
        /// <param name="ProdId"></param>
        /// <param name="strProdName"></param>
        /// <returns></returns>
        [Route("CheckIfProdExist/{ProdId}/{strProdName}")]
        public async Task<bool> CheckIfProdExist(long ProdId, string strProdName)
        {
            return _iproducts.CheckIfProdExist(ProdId, strProdName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newProducts"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Products>> Add(Products newProducts)
        { 
            if (!_iproducts.CheckIfProdExist(0,newProducts.Name))
            {
                var det = await _iproducts.Add(newProducts);
                return Ok();
            }
            else
            { 
                return this.StatusCode(StatusCodes.Status418ImATeapot, "Product Already exist.");
            } 
           
        }
        /// <summary>
        /// Method is used to update the product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newProducts"></param>
        /// <returns></returns>

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutProducts(long id, [FromBody]  Products newProducts)
        {
            if (id != newProducts.Prod_Id)
            {
                return BadRequest();
            }

            var det= await _iproducts.Update(id, newProducts); 

            return NoContent();

        }
        /// <summary>
        ///  Method is used to delete the product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>

        [HttpDelete("{ProductID}")]
        public async Task<ActionResult<Products>> DeleteProducts(long ProductID)
        {
            var Product = await _iproducts.GetById(ProductID);
            if (Product == null)
            {
                return NotFound();
            }
            else
            { 

                var det = await _iproducts.Delete(Product.Value);
            } 

            return Product;
        }


        #endregion
    }
}
