using Sprout.Exam.Business.DataAccess;
using Sprout.Exam.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.BaseServices
{
    public class Employee : BaseDataAccess, IEmployee
    {
        public Employee(IDataAccess pDataAccess) : base(pDataAccess)
        {

        }

        public (bool, int) Add(CreateEmployeeDto input)
        {
            return this.DLEmployee.AddEmployee(input);
        }

        public List<EmployeeDto> Get()
        {
            return this.DLEmployee.GetEmployees();
        }

        public EmployeeDto GetById(int id)
        {
            return this.DLEmployee.GetEmployeeById(id);
        }

        public bool Update(EditEmployeeDto input)
        {
            return this.DLEmployee.UpdateEmployee(input);
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
