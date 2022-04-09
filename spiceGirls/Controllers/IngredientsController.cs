using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spiceGirls.Models;
using spiceGirls.Services;

namespace spiceGirls.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _is;

        public IngredientsController(IngredientsService @is)
        {
            _is = @is;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();

                Ingredient ingredient = _is.Create(ingredientData, userInfo);
                return Ok(ingredientData);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}