using JohnyStoreApi.Models;
using JohnyStoreApi.Models.Sneaker;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SneakerController : ControllerBase
    {
        private readonly ISneakerDataService _sneakerService;

        public SneakerController(ISneakerDataService sneakerService)
        {
            _sneakerService = sneakerService;
        }

        [HttpGet("GetSneakerModels")]
        [AllowAnonymous]
        public List<SneakerModel> GetSneakerModels([FromForm] SearchModel? search)
        {
            return _sneakerService.GetSneakers(search);
        }

        [HttpGet("GetSneakerById/{id}")]
        [AllowAnonymous]
        public SneakerModel GetSneakerById(int id)
        {
            return _sneakerService.GetSneakerByid(id);
        }

        [HttpPost("AddSneaker")]
        [Authorize(Roles = "Admin")]
        //[Consumes("multipart/form-data")]
        public IActionResult AddSneaker([FromForm]AddSneakerModel model)
        {
            bool res = _sneakerService.AddSneaker(model);

            if (!res)
                return BadRequest();

            return Ok();
        }

        [HttpPut("EditSneaker")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditSneaker([FromForm]AddSneakerModel model)
        {
            bool res = _sneakerService.EditSneaker(model);

            if (!res)
                return BadRequest();

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteSneaker/{id}")]
        public IActionResult DeleteSneaker(int id)
        {
            bool res = _sneakerService.DeleteSneaker(id);

            if (!res)
                return BadRequest();

            return Ok();
        }
    }
}
