using JohnyStoreApi.Models.Style;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        private readonly IStyleDataService _styleDataService;

        public StyleController(IStyleDataService styleDataService)
        {
            _styleDataService = styleDataService;
        }

        [HttpGet("GetStyles")]
        [AllowAnonymous]
        public List<StyleModel> GetStyles()
        {
            return _styleDataService.GetStyles();
        }

        [HttpGet("GetStyleById/{id}")]
        [AllowAnonymous]
        public StyleModel GetStyleById(int id) 
        {
            return _styleDataService.GetStyleById(id);
        }

        [HttpPost("AddStyle")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStyle([FromForm] StyleModel model)
        {
            bool res = _styleDataService.AddStyle(model);

            if (!res)
                return BadRequest();

            return Ok();
        }

        [HttpPut("EditStyle")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditStyle([FromForm] StyleModel model)
        {
            bool res = _styleDataService.EditStyle(model);

            if (!res)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("DeleteStyle/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStyle(int id)
        {
            bool res = _styleDataService.DeleteStyle(id);

            if (!res)
                return BadRequest();

            return Ok();
        }
    }
}
