using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DoctSectionViewModel;
using DENTALMIS.Web.Models.EmployeeViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class EmployeeDetailsController : BaseController
    {
        //
        // GET: /EmployeeDetails/
        public ActionResult Index(EmployeeViewModel model)
        {
      

            ModelState.Clear();
            var totalrecords = 0;
            model.Name = model.SearchbyName;
         
            model.Employeedesignations =EmployeeDesignationManager.GetAllDesignation();
            model.Genders = GenderManager.GetAllGenderTitle();
            model.ClinicEmployees =EmployeeManager.GetAllEmployeeByPaging(out totalrecords, model);
                
          

            model.TotalRecords = totalrecords;
       
            return View(model);
        }
        public ActionResult Edit(EmployeeViewModel model)
        {
            model.Genders = GenderManager.GetAllGenderTitle();
            model.Employeedesignations = EmployeeDesignationManager.GetAllDesignation();
            if (model.ClinicEmployeeId > 0)
            {
                ClinicEmployee empl = EmployeeManager.GetEmployeeById(model.ClinicEmployeeId);

                model.ClinicEmployeeId = empl.ClinicEmployeeId;
                model.GenderId = empl.GenderId;
                model.EmployeeDesignationId = empl.EmployeeDesignationId;
                model.Name = empl.Name;
                model.Address = empl.Address;
                model.Salary = empl.Salary;
                model.Contact = empl.Contact;
                model.Email = empl.Email;

               

            }

            return View(model);
        }
        public JsonResult Save(EmployeeViewModel model)
        {
            int saveIndex = 0;

            ClinicEmployee _employee = new ClinicEmployee();

            _employee.ClinicEmployeeId = model.ClinicEmployeeId;
            _employee.GenderId = model.GenderId;
            _employee.EmployeeDesignationId = model.EmployeeDesignationId;
            _employee.Name = model.Name;
            _employee.Salary = model.Salary;
            _employee.Address = model.Address;
            _employee.Contact = model.Contact;
            _employee.Email = model.Email;



            saveIndex = model.ClinicEmployeeId == 0 ? EmployeeManager.Save(_employee) : EmployeeManager.Edit(_employee);


            return Reload(saveIndex);
        }
        public JsonResult Delete(EmployeeViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = EmployeeManager.Delete(model.ClinicEmployeeId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}