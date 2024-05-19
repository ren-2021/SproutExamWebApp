using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sprout.Exam.Business.Model;
using Sprout.Exam.Service.BaseServices;
using Sprout.Exam.WebApp;
using Sprout.Exam.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.Test
{
    public class EmployeeServiceTest
    {

        [Fact]
        public void CreateEmployeeResult()
        {
            var repo = new EmployeeService();
            var employee = new CreateEmployeeDto
            {
                FullName = "Bob",
                Tin = "123213213",
                Birthdate = Convert.ToDateTime("2003-09-09").Date,
                TypeId = 1
            };
            var convertEmployee = JsonConvert.DeserializeObject<EmployeeDto>(JsonConvert.SerializeObject(employee));
            List<BaseSaveEmployeeDto> employeeDtos = new List<BaseSaveEmployeeDto> { employee };

            var result = repo.Add(employee);
            var getresult = repo.Get();

            Assert.Equal(convertEmployee.FullName, getresult.Last().FullName);
            Assert.Equal(convertEmployee.Tin, getresult.Last().Tin);
            Assert.Equal<int>(convertEmployee.TypeId, getresult.Last().TypeId);
        }

        [Fact]
        public void CalculateRegularSalaryResult()
        {
            var repo = new EmployeeService();

            //Regular
            var employee = repo.Get().Where(x => x.Id == 2);
            decimal computeSalary = repo.Compute(2, 1, 0);
            //Regular (Expected)
            var employeeTest = new { Salary = 20000m, AbsentDays = 1m, TaxRate = 0.12m};
            decimal deduction = (employeeTest.Salary / 22) * employeeTest.AbsentDays;
            decimal taxDeduction = employeeTest.Salary * employeeTest.TaxRate;
            decimal expectedSalary = employeeTest.Salary - deduction - taxDeduction;

            Assert.Equal<decimal>(Convert.ToDecimal(expectedSalary.ToString("F2")), computeSalary);

        }

        [Fact]
        public void CalculateContractualSalaryResult()
        {
            var repo = new EmployeeService();

            //Contractual
            var employee = repo.Get().Where(x => x.Id == 2);
            decimal computeSalary = repo.Compute(5, 0, 15.5m);
            //Contractual (Expected)
            var employeeTest = new { Salary = 500m, WorkedDays = 15.5m };
            decimal expectedSalary = employeeTest.Salary * employeeTest.WorkedDays;

            Assert.Equal<decimal>(Convert.ToDecimal(expectedSalary.ToString("F2")), computeSalary);

        }
    }
}

