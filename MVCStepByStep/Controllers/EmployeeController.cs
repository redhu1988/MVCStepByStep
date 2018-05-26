using MVCStepByStep.Models;
using MVCStepByStep.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStepByStep.Controllers
{
    public class EmployeeController:Controller
    {
        public ActionResult Index()
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
                else
                {
                    empVM.SalaryColor = "green";
                }
                empViewModelList.Add(empVM);
            }

            empListView.Employees = empViewModelList;
            
            return View("Index",empListView);
        }
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        public ActionResult SaveEmployee(Employee e,string BtnSubmit)
        {
            //Employee e = new Employee();
            //e.FirstName = Request.Form["FName"];
            //e.LastName = Request.Form["LName"];
            //e.Salary = int.Parse(Request.Form["Salary"]);
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer embl = new EmployeeBusinessLayer();
                        embl.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else {
                        return View("CreateEmployee");
                    }
                case "Cancel":
                    return RedirectToAction("Index");
                      
            }
            return new EmptyResult();
        }
    }
}