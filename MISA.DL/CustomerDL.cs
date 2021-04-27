using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;
using MySqlConnector;
using System.Linq;

namespace MISA.DL
{
    public class CustomerDL:BaseDL
    {
      

        //public Customer GetCustomerById(Guid customerId)
        //{

        //    using (_dbConnection = new MySqlConnection(_connectionString))
        //    {
        //        // 3. Thực thi lệnh lấy dữ liệu trong Database:
        //        var sqlCommand = $"SELECT * FROM Customer WHERE CustomerId = '{customerId.ToString()}'";
        //        var customer = _dbConnection.QueryFirstOrDefault<Customer>(sqlCommand);
        //        return customer;
        //    }
           
        //}

        //public int InsertCustomer(Customer customer)
        //{
        //    using (_dbConnection = new MySqlConnection(_connectionString))
        //    {
        //        // 3. Thực thi lệnh lấy dữ liệu trong Database:
        //        var sqlCommand = $"Proc_InsertCustomer";
        //        var rowAffects = _dbConnection.Execute(sqlCommand, param: customer, commandType: CommandType.StoredProcedure);
        //        return rowAffects;
        //    }

        //}

        //public int UpdateCustomer(Customer customer)
        //{
        //    return 0;
        //}

        //public int DeleteCustomer(Customer customer)
        //{
        //    return 0;
        //}

        public bool CheckCustomerCodeExist(string customerCode)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Thực thi lệnh lấy dữ liệu trong Database:
                var sqlCommand = $"Proc_CheckCustomerCodeExists";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerCode", customerCode);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }
        }
    }
}
