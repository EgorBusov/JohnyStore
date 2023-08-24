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

        [Route("GetStyles")]
        [HttpGet]
        [AllowAnonymous]
        public List<StyleModel> GetStyles()
        {
            return _styleDataService.GetStyles();
        }

        [Route("GetStyleById")]
        [HttpGet]
        [AllowAnonymous]
        public StyleModel GetStyleById(int id) 
        {
            return _styleDataService.GetStyleById(id);
        }

        [Route("AddStyle")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStyle([FromBody] StyleModel model)
        {
            bool res = _styleDataService.AddStyle(model);

            if (!res)
                return BadRequest();

            return Ok();
        }

        [Route("EditStyle")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult EditStyle([FromBody] StyleModel model)
        {
            bool res = _styleDataService.EditStyle(model);

            if (!res)
                return BadRequest();

            return Ok();
        }

        [Route("Delete/{id}")]
        [HttpDelete("{id}")]
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
