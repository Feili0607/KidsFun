using KidsFun.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidsFun.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KidController : ControllerBase
    {
        private readonly ILogger<KidController> _logger;
        private readonly IKidManager _manager;

        public KidController(IKidManager manager, ILogger<KidController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int kidId)
        {
            if (kidId <= 0)
                return BadRequest("Invalid kid Id");
            var kid = await _manager.GetKidAsync(kidId);
            return Ok(kid);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(KidDetail kid)
        {
             await _manager.CreateKidAsync(kid);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int kidId)
        {
            await _manager.DeleteKidAsync(kidId);

            return Ok();
        }
    }
}