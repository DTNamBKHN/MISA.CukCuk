using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Exceptions;
using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            CustomerGroupBL customerGroupBL =  new CustomerGroupBL();
            var customers = customerGroupBL.GetAll<CustomerGroup>();
            // 4. Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            else
            {
                return NoContent();
            }

        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            CustomerGroupBL customerBL = new CustomerGroupBL();
            var customer = customerBL.GetById<CustomerGroup>(id);
            // 4. Trả về cho Client:
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }


        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroup customerGroup)
        {
            try
            {

                CustomerGroupBL customerGroupBL = new CustomerGroupBL();
                var rowAffects = customerGroupBL.Insert(customerGroup);
                // 4. Trả về cho Client:
                if (rowAffects > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<CustomerGroup> ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = "CustomerCode",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {

                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "CustomerCode"
                };
                return StatusCode(500, mes);
            }

        }
    }
}
