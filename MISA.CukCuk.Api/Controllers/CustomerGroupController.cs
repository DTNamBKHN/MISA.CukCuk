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
    public class CustomerGroupController : BaseController<CustomerGroup>
    {
        /*
        // GET: api/v1/<CustomerGroupController>
        [HttpGet]
        public IActionResult Get()
        {
            CustomerGroupBL customerGroupBL = new CustomerGroupBL();
            var customerGroups = customerGroupBL.GetAll<CustomerGroup>();
            if (customerGroups.Count() > 0)
            {
                return Ok(customerGroups);
            }
            else
            {
                return NoContent();
            }

        }
        // GET api/v1/<CustomerGroupController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            CustomerGroupBL customerGroupBL = new CustomerGroupBL();
            var customerGroup = customerGroupBL.GetById<CustomerGroup>(id);
            // 4. Trả về cho Client:
            if (customerGroup != null)
            {
                return Ok(customerGroup);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<CustomerGroupController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroup customerGroup)
        {
            try
            {
                CustomerGroupBL customerGroupBL = new CustomerGroupBL();
                var rowAffects = customerGroupBL.Insert<CustomerGroup>(customerGroup);
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
                    field = "CustomerGroupCode",
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
                    field = "CustomerGroupCode"
                };
                return StatusCode(500,mes);
            }
        }
        // PUT api/<CustomerGroupController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CustomerGroup customerGroup)
        {
            CustomerGroupBL customerGroupBL = new CustomerGroupBL();
            var res = customerGroupBL.Update<CustomerGroup>(customerGroup, id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/<CustomerGroupController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            CustomerGroupBL customerGroupBL = new CustomerGroupBL();
            var res = customerGroupBL.Delete<CustomerGroup>(id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }
        */
    }
}
