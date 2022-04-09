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
    public class StepsController : ControllerBase
    {
        private readonly StepsService _ss;

        public StepsController(StepsService ss)
        {
            _ss = ss;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Step>> Create([FromBody] Step stepData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Step step = _ss.Create(stepData);
                return Ok(step);

            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Step>> Update([FromBody] Step stepUpdate, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                stepUpdate.Id = id;
                Step step = _ss.Update(stepUpdate, userInfo);
                return Ok(step);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}