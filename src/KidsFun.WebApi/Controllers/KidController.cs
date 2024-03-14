using KidsFun.Models;
using KidsFun.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace KidsFun.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class KidController : ControllerBase
    {
        private readonly ILogger<KidController> _logger;
        private readonly IKidManager _manager;

        public KidController(IKidManager manager, ILogger<KidController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet("{kidId}")]
        public async Task<IActionResult> GetAsync(int kidId)
        {
            if (kidId <= 0)
                return BadRequest("Invalid kid Id");
            try
            {
                var kid = await _manager.GetKidAsync(kidId);
                return Ok(kid);
            }
            catch(ArgumentException)
            {
                return NotFound($"Kid with Id = {kidId} can not be found");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            var kids = await _manager.GetKidsAsync();
            return Ok(kids);

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(NewKidDto newKidDto)
        {
            const string pattern = @"^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$";
            if (string.IsNullOrEmpty(newKidDto.Email) || !Regex.IsMatch(newKidDto.Email, pattern))
                return BadRequest("Invalid email.");

            var newKid = new KidDetail
            {
                Name = newKidDto.Name,
                DateOfBirth = newKidDto.BirthDate,
                EmailAddress = newKidDto.Email,
                Gender = newKidDto.Gender,
            };
            
            var createdKid = await _manager.CreateKidAsync(newKid);

            return Ok(createdKid);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int kidId)
        {
            await _manager.DeleteKidAsync(kidId);

            return NoContent();
        }
    }
}