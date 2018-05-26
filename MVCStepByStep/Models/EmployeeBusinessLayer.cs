using MVCStepByStep.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCStepByStep.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL sales = new SalesERPDAL();
            sales.Employees.Add(e);
            sales.SaveChanges();
            return e;
        }
    }
}