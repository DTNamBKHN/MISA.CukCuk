using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;
using MISA.BL;
using MISA.Common.Entities;
using MISA.BL.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            CustomerBL customerBL = new CustomerBL();
            var customers = customerBL.GetAll<Customer>();
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

        [HttpGet("Paging")]
        public IActionResult GetPaging(int pageIndex, int pageSize)
        {
            // 1. Khai báo thông tin kết nối tới Database:
            var connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database= MF0_NVManh_CukCuk02;" +
                "User Id = dev;" +
                "Password= 12345678";

            // 2. Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Tương tác với Database (lấy dữ liệu, sửa dữ liệu, xóa dữ liệu)
            var sqlCommand = "Proc_GetCustomerPaging";
            var param = new
            {
                m_PageIndex = 1,
                m_PageSize = 10
            };

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@m_PageIndex", 1);
            dynamicParameters.Add("@m_PageSize", 10);

            var customers = dbConnection.Query<Customer>(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);

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
            CustomerBL customerBL = new CustomerBL();
            var customer = customerBL.GetById<Customer>(id);
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
        public IActionResult Post([FromBody] Customer customer)
        {
            try
            {

                CustomerBL customerBL = new CustomerBL();
                var rowAffects = customerBL.Insert(customer);
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
            catch (GuardException<Customer> ex)
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
                return StatusCode(500,mes);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Customer customer)
        {
            CustomerBL customerBL = new CustomerBL();
            var res = customerBL.Update(customer, id);
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
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
