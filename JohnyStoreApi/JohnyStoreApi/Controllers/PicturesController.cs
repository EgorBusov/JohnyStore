using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureDataService _pictureDataService;
        private readonly string _contentType;

        public PicturesController(IPictureDataService pictureDataService) 
        {
            _pictureDataService = pictureDataService;
            _contentType = "image/jpeg";
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Get")]
        public IActionResult GetPicture(string path)
        {
            var stream = _pictureDataService.GetPicture(path);
            return File(stream, _contentType);
        }
    }
}
