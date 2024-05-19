using Sprout.Exam.Business.BaseServices;
using Sprout.Exam.Business.DataAccess;
using Sprout.Exam.Business.Model;
using Sprout.Exam.DataAccess.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Service.BaseServices
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployee employee;
        private IDataAccess dataAccess;

        public EmployeeService()
        {
            this.dataAccess = new DLEmployee();
            this.employee = new Employee(dataAccess);
        }

        public (bool, int, int) Add(CreateEmployeeDto input)
        {
            return this.employee.Add(input);
        }

        public List<EmployeeDto> Get()
        {
            return this.employee.Get();
        }

        public EmployeeDto GetById(int id)
        {
            return this.employee.GetById(id);
        }

        public (bool, int) Update(EditEmployeeDto input)
        {
            return this.employee.Update(input);
        }

        public bool Delete(int id)
        {
            return this.employee.Delete(id);
        }

        public decimal Compute(int id, decimal absentDays, decimal workedDays)
        {
            return this.employee.Compute(id, absentDays, workedDays);
        }
    }
}
