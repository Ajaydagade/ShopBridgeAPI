 
using Microsoft.AspNetCore.Mvc;
using ShopBridge_Data.Interfaces; 
using System.Threading.Tasks;

namespace ShopBridgeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        #region Variable Declaration 
        IEmployee _iemployee;
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="products"></param>
        public LoginController(IEmployee iemployee)
        {
            _iemployee = iemployee;
        }
        /// <summary>
        /// method used for authentication
        /// </summary>
        /// <param name="strEmail"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool>  GetById(string strEmail, string strPassword)
        {
            return await _iemployee.GetById(strEmail, strPassword);
        }
    }

}
