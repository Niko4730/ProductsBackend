using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
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
        public ActionResult<ProductDto> Add([FromBody]Product product)
        {
            try
            {
                Product p = _productService.Create(product.Id, product.Name);
                return Ok(new ProductDto {Id = p.Id, Name = p.Name});
            }
            catch (Exception e)
            {
                return StatusCode(500, "U suck");
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
        public ActionResult<ProductDto> ReadById(int id)
        {
            try
            {
                Product p = _productService.GetById(id);
                return Ok(new ProductDto {Id = p.Id});
            }
            catch (Exception e)
            {
                return StatusCode(500, "You did something wrong");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> Delete(int id)
        {
            try
            {
                Product p = _productService.Delete(id);
                return Ok(new ProductDto {Id = p.Id});
            }
            catch (Exception e)
            {
                return StatusCode(500, "You messed up");
            }
        }

        [HttpPut("{id}")]

    public ActionResult<ProductDto> Update(int id, [FromBody]Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest("Id is invalid");
                }
                product.Id = id;
                Product p = _productService.Update(id, product);
                
                return Ok(new ProductDto{Id = p.Id, Name = p.Name});
            }
            catch (Exception e)
            {
                return StatusCode(500, "bruh, cmon");
            }
        }

    }
}