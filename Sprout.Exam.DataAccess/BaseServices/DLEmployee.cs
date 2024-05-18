using Dapper;
using Sprout.Exam.Business.Model;
using Sprout.Exam.DataAccess.BaseDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Sprout.Exam.DataAccess.BaseServices
{
    public class DLEmployee : DLBaseDataAccess, IDLEmployee
    {
        public bool AddEmployee(CreateEmployeeDto input)
        {
            bool IsSuccess = false;
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@FullName", input.FullName);
                    parameters.Add("@Tin", input.Tin);
                    parameters.Add("@Birthdate", input.Birthdate);
                    parameters.Add("@TypeId", input.TypeId);
                    parameters.Add("@IsSuccess", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    connection.Execute("pr_AddEmployee", parameters, commandType: CommandType.StoredProcedure);
                    IsSuccess = parameters.Get<bool>("@IsSuccess");
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return IsSuccess;
        }

        public EmployeeDto GetEmployees(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployees(EditEmployeeDto input)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public decimal Calculate(int id, decimal absentDays, decimal workedDays)
        {
            throw new NotImplementedException();
        }
    }
}
