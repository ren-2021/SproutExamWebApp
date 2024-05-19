using Sprout.Exam.Business.Model;
using Sprout.Exam.DataAccess.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Service.BaseServices
{
    public interface IEmployeeService
    {
        public (bool, int, int) Add(CreateEmployeeDto input);

        public List<EmployeeDto> Get();
        public EmployeeDto GetById(int id);

        public (bool, int) Update(EditEmployeeDto input);

        public bool Delete(int id);

        public decimal Compute(int id, decimal absentDays, decimal workedDays);
    }
}
