using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_exam_project.core.ApplicationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRange.Core.Entity;

namespace TheRange.UI.Rest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            try
            {
                return Ok(_customerService.CreateCustomer(customer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpGet("{id}")]
        public Customer GetCustomerByID(int id)
        {
            return _customerService.GetCustomerById(id);
        }

        [Authorize(Roles = "administrator")]
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomer()
        {
            return Ok(_customerService.GetCustomer());
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {
            try
            {
                if (id != customer.Id)
                {
                    return BadRequest("Parameter ID and customer ID have to be the same");
                }
                return Ok(_customerService.UpdateCustomer(id,customer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _customerService.DeleteCustomer(id);
                return Ok($"Deleted owner with Id: {id}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}