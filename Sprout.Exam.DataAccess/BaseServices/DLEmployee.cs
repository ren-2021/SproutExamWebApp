using Sprout.Exam.Business.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sprout.Exam.DataAccess.BaseServices
{
    public class DLEmployee : IDLEmployee
    {
        public bool AddEmployee(CreateEmployeeDto input)
        {
            throw new NotImplementedException();
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
