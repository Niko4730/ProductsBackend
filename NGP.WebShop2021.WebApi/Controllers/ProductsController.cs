using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGP.WebShop2021.Core.IServices;
using NGP.WebShop2021.Core.Models;
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

        [HttpPost]
        public ActionResult<ProductsDto> Create(int id, string name)
        {
            try
            {
                return Ok(_productService.Create(id, name));
            }
            catch (Exception e)
            {
                return StatusCode(500, "You cant create that...");
            }
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

        [HttpGet("{id}")]
        public ActionResult<ProductsDto> ReadById(int id)
        {
            try
            {
                return Ok(_productService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "You did something wrong");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductsDto> Delete(int id)
        {
            try
            {
                return Ok(_productService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "You messed up");
            }
        }

        [HttpPut("{id")]
        public ActionResult<ProductsDto> Update(int id, [FromBody]Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest("Id is invalid");
                }
                product.Id = id;
                
                return Ok(_productService.Update(id, product));
            }
            catch (Exception e)
            {
                return StatusCode(500, "bruh, cmon");
            }
        }

    }
}