using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.Model
{
    public class EmployeeDto: BaseSaveEmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Birthdate { get; set; }
        public string Tin { get; set; }
        public int TypeId { get; set; }

        public static explicit operator EmployeeDto(CreateEmployeeDto v)
        {
            throw new NotImplementedException();
        }
    }
}
