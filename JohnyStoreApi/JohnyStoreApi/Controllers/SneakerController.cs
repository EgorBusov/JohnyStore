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

        [Route("GetSneakers")]
        [HttpGet]
        [AllowAnonymous]
        public List<SneakerModel> GetSneakerModels(SearchModel? search)
        {
            return _sneakerService.GetSneakers(search);
        }

        [Route("GetSneakerById/{id}")]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public SneakerModel GetSneakerById(int id)
        {
            return _sneakerService.GetSneakerByid(id);
        }

        [Route("Add")]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddSneaker(AddSneakerModel model)
        {
            bool res = _sneakerService.AddSneaker(model);

            if (!res)
                return BadRequest();

            return Ok();
        }

        [Route("Edit")]
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult EditSneaker([FromForm] AddSneakerModel model)
        {
            bool res = _sneakerService.EditSneaker(model);

            if (!res)
                return BadRequest();

            return Ok();
        }

        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSneaker(int id)
        {
            bool res = _sneakerService.DeleteSneaker(id);

            if (!res)
                return BadRequest();

            return Ok();
        }
    }
}
