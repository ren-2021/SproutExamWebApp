using Sprout.Exam.Business.DataAccess;
using Sprout.Exam.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.BaseServices
{
    public class EmployeeService : BaseDataAccess, IEmployeeService
    {
        public EmployeeService(IDataAccess pDataAccess, IDataAccessFactory dataFactory) : base(pDataAccess, dataFactory)
        {

        }

        public bool Add(CreateEmployeeDto input)
        {
            return this.DLEmployee.AddEmployee(input);
        }

        public EmployeeDto Get(int id)
        {
            return this.DLEmployee.GetEmployees(id);
        }

        public bool Update(EditEmployeeDto input)
        {
            return this.DLEmployee.UpdateEmployees(input);
        }

        public bool Delete(int id)
        {
            return this.DLEmployee.DeleteEmployee(id);
        }

        public decimal Compute(int id, decimal absentDays, decimal workedDays)
        {
            return this.DLEmployee.Calculate(id, absentDays, workedDays);
        }

     
    }
}
