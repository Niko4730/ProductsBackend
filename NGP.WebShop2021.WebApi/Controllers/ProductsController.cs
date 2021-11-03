using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGP.WebShop2021.WebApi.Dtos;

namespace NGP.WebShop2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]

        public ActionResult<ProductsDto> ReadAll()
        {
            var dto = new ProductsDto();
            dto.List = new List<ProductDto>
            {
                new ProductDto() {Id = 1, Name = "Ko"},
                new ProductDto() {Id = 2, Name = "Kat"},
                new ProductDto() {Id = 3, Name = "Hund"}
            };
            return Ok(dto);
        } 
    }
}