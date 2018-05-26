using MVCStepByStep.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCStepByStep.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [FirstNameValidation]
        public string FirstName { get; set; }
        [StringLength(8,ErrorMessage ="Last Name Shoul Not Be Greater than 8")]
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}