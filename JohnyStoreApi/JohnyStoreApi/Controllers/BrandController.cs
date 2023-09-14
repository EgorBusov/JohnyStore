using JohnyStoreApi.Models.Brand;
using JohnyStoreApi.Services.Interfaces.DataInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JohnyStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandDataService _brandDataService;

        public BrandController(IBrandDataService brandDataService)
        {
            _brandDataService = brandDataService;
        }

        /// <summary>
        /// Получение списка всех брендов
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetBrands")]
        public List<BrandModel> GetBrands()
        {
            return _brandDataService.GetBrands();
        }

        /// <summary>
        /// Получение бренда по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("GetBrandByid/{id}")]
        public BrandModel GetBrandByid(int id) 
        {
            return _brandDataService.GetBrandById(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddBrand")]
        public IActionResult AddBrand([FromBody] AddBrandModel model)
        {
            bool check = _brandDataService.AddBrand(model);

            if (check)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Редактирований бренда
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("EditBrand")]
        public IActionResult EditBrand([FromBody] AddBrandModel model)
        {
            bool check = _brandDataService.EditBrand(model);

            if (check)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Удаление бренда
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteBrand/{id}")]
        public IActionResult DeleteBrand(int id)
        {
            bool check = _brandDataService.DeleteBrand(id);

            if (check)
                return Ok();

            return BadRequest();
        }
    }
}
