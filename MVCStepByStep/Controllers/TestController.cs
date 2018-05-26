using MVCStepByStep.Models;
using MVCStepByStep.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStepByStep.Controllers
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return this.CustomerName + "|" + this.Address;
        }
    }
    public class TestController : Controller
    {
        // GET: Test
        public Customer GetCustomer()
        {
            var customer = new Customer() { CustomerName = "Redhu", Address = "CHD" };
            return customer;
        }
        [NonAction]
        public string SimpleMethod()
        {
            return "asd";
        }
        public ActionResult GetView()
        {
            EmployeeListViewModel empListView = new EmployeeListViewModel();
            EmployeeBusinessLayer empBuisnessLayer = new EmployeeBusinessLayer();
            var employees = empBuisnessLayer.GetEmployees();
            List<EmployeeViewModel> empViewModelList = new List<EmployeeViewModel>();
            foreach (Employee employee in employees)
            {
                var empVM = new EmployeeViewModel();
                empVM.EmployeeName = employee.FirstName + " " + employee.LastName;
                empVM.Salary = employee.Salary.ToString("C");

                if (employee.Salary > 15000)
                {
                    empVM.SalaryColor = "yellow";
                }
                else {
                    empVM.SalaryColor = "green";
                }
                empViewModelList.Add(empVM);
            }

            empListView.Employees = empViewModelList;
           // empListView.UserName = "Parmod";
            return View("MyView", empListView);
        }

    }
}