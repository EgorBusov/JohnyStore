using JohnyStoreApi.Models.Picture;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureSneakerDataService _pictureSneakerDataService;
        private readonly IPictureBrandDataService _pictureBrandDataService;
        private readonly string _contentType;

        public PictureController(IPictureSneakerDataService pictureDataService, IPictureBrandDataService pictureBrandDataService) 
        {
            _pictureSneakerDataService = pictureDataService;
            _pictureBrandDataService = pictureBrandDataService;
            _contentType = "image/jpeg";
        }

        [HttpGet("GetSneakerPicture/{path}")]
        [AllowAnonymous]
        public IActionResult GetSneakerPicture(string path)
        {
            var stream = _pictureSneakerDataService.GetPicture(path);
            return File(stream, _contentType);
        }

        [HttpGet("GetBrandPicture/{path}")]
        [AllowAnonymous]
        public IActionResult GetBrandPicture(string path)
        {
            var stream = _pictureBrandDataService.GetPicture(path);
            return File(stream, _contentType);
        }
    }
}
