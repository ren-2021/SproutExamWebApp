using Sprout.Exam.Business.DataAccess;
using Sprout.Exam.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.BaseServices
{
    public class Employee : BaseDataAccess, IEmployee
    {
        private bool isValid;
        public Employee(IDataAccess pDataAccess) : base(pDataAccess)
        {

        }

        public (bool, int, int) Add(CreateEmployeeDto input)
        {
            isValid = true;
            this.Validation(input);
            if (isValid == false)
            {
                return (false, 0, 422);
            }
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

        public (bool, int) Update(EditEmployeeDto input)
        {
            isValid = true;
            var isSuccess = false;
            this.Validation(input);
            if (isValid == false)
            {
                return (false, 422);
            }
            isSuccess = this.DLEmployee.UpdateEmployee(input);
            if(!isSuccess)
            {
                return (false, 422);
            }
            return (isSuccess, 200);
        }

        public bool Delete(int id)
        {
            return this.DLEmployee.DeleteEmployee(id);
        }

        public decimal Compute(int id, decimal absentDays, decimal workedDays)
        {
            return this.DLEmployee.Calculate(id, absentDays, workedDays);
        }

        private void Validation(BaseSaveEmployeeDto input)
        {
            DateTime minValue = Convert.ToDateTime("1-1-1753 12:00:00");
            DateTime maxValue = DateTime.MaxValue;
            if (input == null || string.IsNullOrEmpty(input.FullName) || string.IsNullOrEmpty(input.Tin) || input.Birthdate == null)
            {
                isValid = false;
            }
            if (input.Birthdate < minValue || input.Birthdate > maxValue)
            {
                isValid = false;
            }
        }
    }
}
