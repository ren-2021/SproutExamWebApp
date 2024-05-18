using Sprout.Exam.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.BaseServices
{
    public interface IDLEmployee
    {
        public bool AddEmployee(CreateEmployeeDto input);

        public EmployeeDto GetEmployees(int id);

        public bool UpdateEmployees(EditEmployeeDto input);

        public bool DeleteEmployee(int id);

        public decimal Calculate(int id, decimal absentDays, decimal workedDays);
    }
}
