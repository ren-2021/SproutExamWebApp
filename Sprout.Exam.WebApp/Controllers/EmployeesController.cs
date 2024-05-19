using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Business.Model;
using Sprout.Exam.Service.BaseServices;
using Sprout.Exam.WebApp.Models;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            var result = await Task.FromResult<IEnumerable<EmployeeDto>>(this.employeeService.Get());
            return result;
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<EmployeeDto> GetById(int id)
        {
            var result = await Task.FromResult<EmployeeDto>(this.employeeService.GetById(id));
            return result;
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            var result = await Task.FromResult<(bool isSuccess, int Error)>(this.employeeService.Update(input));
            if(result.isSuccess == false)
            {
                return StatusCode(result.Error);
            }
            return Ok(result);
        }

        ///// <summary>
        ///// Refactor this method to go through proper layers and insert employees to the DB.
        ///// </summary>
        ///// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            var result = await Task.FromResult<(bool isSuccess, int id, int Error)>(this.employeeService.Add(input));
            if (result.isSuccess == false)
            {
                return StatusCode(result.Error);
            }
            return Created($"/api/employees/{result.id}", result.id);
        }

        ///// <summary>
        ///// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        ///// </summary>
        ///// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Task.FromResult<bool>(this.employeeService.Delete(id));
            return Ok(result);
        }

        ///// <summary>
        ///// Refactor this method to go through proper layers and use Factory pattern
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="absentDays"></param>
        ///// <param name="workedDays"></param>
        ///// <returns></returns>
        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate([FromBody] CalculationData calData)
        {
            //I use stored procedure instead of application code in calculating Salary for scalability and centralization
            var result = await Task.FromResult<decimal>(this.employeeService.Compute(calData.Id, calData.AbsentDays, calData.WorkedDays));
            return Ok(result);
        }
    }
}
