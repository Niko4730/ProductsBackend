using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGP.WebShop2021.Core.IServices;
using NGP.WebShop2021.WebApi.Dtos;

namespace NGP.WebShop2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]

        public ActionResult<ProductsDto> ReadAll()
        {
            try
            {
                var products = _productService.GetAll()
                    .Select(p => new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToList();
                return Ok(new ProductsDto
                {
                    List = products
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
    }
}