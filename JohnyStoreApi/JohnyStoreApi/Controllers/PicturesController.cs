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
        private readonly IPictureSneakerDataService _pictureSneakerDataService;
        private readonly IPictureBrandDataService _pictureBrandDataService;
        private readonly string _contentType;

        public PicturesController(IPictureSneakerDataService pictureDataService) 
        {
            _pictureSneakerDataService = pictureDataService;
            _contentType = "image/jpeg";
        }

        [HttpGet("{path}")]
        [AllowAnonymous]
        [Route("GetSneakerPicture/{path}")]
        public IActionResult GetSneakerPicture(string path)
        {
            var stream = _pictureSneakerDataService.GetPicture(path);
            return File(stream, _contentType);
        }

        [HttpGet("{path}")]
        [AllowAnonymous]
        [Route("GetBrandPicture/{path}")]
        public IActionResult GetBrandPicture(string path)
        {
            var stream = _pictureBrandDataService.GetPicture(path);
            return File(stream, _contentType);
        }
    }
}
