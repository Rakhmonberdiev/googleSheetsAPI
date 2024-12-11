using googleSheetsAPI.Models;
using googleSheetsAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace googleSheetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserDataController : ControllerBase
    {
        private readonly IGoogleSheetsService _googleSheetsService;
        private readonly ILogger<UserDataController> _logger;
        public UserDataController(IGoogleSheetsService googleSheetsService, ILogger<UserDataController> logger)
        {
            _googleSheetsService = googleSheetsService;
            _logger = logger;

        }
        [HttpPost]
        public async Task<ActionResult> PostData(UserData model)
        {
            try
            {
               var isSuccess =  await _googleSheetsService.Create(model);
               if (isSuccess) return NoContent();
                return BadRequest("Google ga malumot qoshishda muammo buldi");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}
