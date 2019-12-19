using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRange.Core.ApplicationService;
using TheRange.Core.Entity;


namespace TheRange.UI.Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>>  Get()
        {
            try
            {
                return Ok(_productService.ReadAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int Id)
        {
            try
            {
                return Ok(_productService.ReadByID(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // POST api/products
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product value)
        {
            try
            {
                return Ok(_productService.CreateProduct(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        // PUT api/products/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product productValue)
        {
            try
            {
                if (id != productValue.Id)
                {
                    return BadRequest("Parameter ID does not match Product id");
                }
                return Ok(_productService.UpdateProduct(id , productValue));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/products/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            Product deletedProduct = _productService.DeleteProduct(id);
            if (deletedProduct == null)
            {
                return StatusCode(404, $"Did not find Product with ID: {id}");
            }
            return Ok(deletedProduct);
        }


    }
}
