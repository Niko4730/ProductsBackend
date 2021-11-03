using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGP.WebShop2021.WebApi.Controllers.Dtos;

namespace NGP.WebShop2021.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]

        public ActionResult<ProductsDto> ReadAll()
        {
            
        }
    }
}