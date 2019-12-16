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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_orderService.GetFilteredOrders(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            try
            {
                return Ok(_orderService.ReadAllOrders());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            try
            {
                return Ok(_orderService.ReadById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            try
            {
                return Ok(_orderService.CreateOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Order> Put(int id, [FromBody] Order value)
        {
            try
            {
                if (id != value.id)
                {
                    return BadRequest("Parameter ID does not match Order id");
                }
                return Ok(_orderService.Update(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            Order deletedOrder = _orderService.Delete(id);
            if (deletedOrder == null)
            {
                return StatusCode(404, $"Did not find Order with ID: {id}");
            }
            return Ok(deletedOrder);
        }


    }
}