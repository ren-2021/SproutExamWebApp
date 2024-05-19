using Dapper;
using Sprout.Exam.Business.DataAccess;
using Sprout.Exam.Business.Model;
using Sprout.Exam.DataAccess.BaseDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Sprout.Exam.DataAccess.BaseServices
{
    public class DLEmployee : DLBaseDataAccess, IDataAccess, IDLEmployee
    {
        public (bool, int, int) AddEmployee(CreateEmployeeDto input)
        {
            (bool IsSuccess, int Id, int ErrorCode) result = (false, 0, 500);
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
                    result = connection.Query<(bool, int, int)>("pr_CreateEmployee", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return result;
            }

            return result;
        }

        public List<EmployeeDto> GetEmployees()
        {
            List<EmployeeDto> result = new List<EmployeeDto>();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    result = connection.Query<EmployeeDto>("pr_GetEmployees", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            EmployeeDto result = new EmployeeDto();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    result = connection.Query<EmployeeDto>("pr_GetEmployeeById", new { Id = id}, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool UpdateEmployee(EditEmployeeDto input)
        {
            bool IsSuccess = false;
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", input.Id);
                    parameters.Add("@FullName", input.FullName);
                    parameters.Add("@Tin", input.Tin);
                    parameters.Add("@Birthdate", input.Birthdate);
                    parameters.Add("@TypeId", input.TypeId);
                    parameters.Add("@IsSuccess", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    connection.Execute("pr_UpdateEmployee", parameters, commandType: CommandType.StoredProcedure);
                    IsSuccess = parameters.Get<bool>("@IsSuccess");
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return IsSuccess;
        }

        public bool DeleteEmployee(int id)
        {
            bool IsSuccess = false;
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);
                    parameters.Add("@IsSuccess", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                    connection.Execute("pr_DeleteEmployee", parameters, commandType: CommandType.StoredProcedure);
                    IsSuccess = parameters.Get<bool>("@IsSuccess");
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return IsSuccess;
        }

        public decimal Calculate(int id, decimal absentDays, decimal workedDays)
        {
            decimal totalcompute;
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    totalcompute = connection.Query<decimal>("pr_CalculateEmployeeSalary", 
                        new { 
                            Id = id,
                            AbsentDays = absentDays,
                            WorkedDays = workedDays
                        }, 
                        commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return totalcompute;
        }
    }
}
