using Sprout.Exam.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.BaseServices
{
    public interface IEmployee
    {
        public (bool, int) Add(CreateEmployeeDto input);
        public List<EmployeeDto> Get();
        public EmployeeDto GetById(int id);
        public bool Update(EditEmployeeDto input);
        public bool Delete(int id);
        public decimal Compute(int id, decimal absentDays, decimal workedDays);
    }
}
