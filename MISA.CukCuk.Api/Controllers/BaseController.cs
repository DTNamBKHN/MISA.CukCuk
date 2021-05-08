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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        // GET: api/v1/<Controller>
        [HttpGet]
        public IActionResult Get()
        {
            BaseBL baseBL = new BaseBL();
            var entities = baseBL.GetAll<MISAEntity>();
            // 4. Kiểm tra dữ liệu và trả về cho Client
            // - Nếu có dữ liệu thì trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/v1/<Controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            BaseBL baseBL = new BaseBL();
            var entity = baseBL.GetById<MISAEntity>(id);
            // 4. Trả về cho Client:
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/v1/<Controller>
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            try
            {

                BaseBL baseBL = new BaseBL();
                var rowAffects = baseBL.Insert<MISAEntity>(entity);
                // 4. Trả về cho Client:
                if (rowAffects > 0)
                {
                    return Ok(rowAffects);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<MISAEntity> ex)
            {
                var entityName = typeof(MISAEntity).Name;
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = $"{entityName}Code",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {
                var entityName = typeof(MISAEntity).Name;
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = $"{entityName}Code",
                };
                return StatusCode(500, mes);
            }
        }


        // PUT api/v1/<Controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MISAEntity entity)
        {
            BaseBL baseBL = new BaseBL();
            var res = baseBL.Update<MISAEntity>(entity, id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            BaseBL baseBL = new BaseBL();
            var res = baseBL.Delete<MISAEntity>(id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
