using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.EmployeeViewModel
{
    public class EmployeeViewModel:ClinicEmployee
    {

        public List<ClinicEmployee> ClinicEmployees { get; set; }


        public List<Gender> Genders { get; set; }


        public List<Employeedesignation> Employeedesignations { get; set; }

        public string SearchbyName { get; set; }

        public EmployeeViewModel()
        {
            ClinicEmployees=new List<ClinicEmployee>();
            Genders=new List<Gender>();
            Employeedesignations=new List<Employeedesignation>();
        }

        public virtual IEnumerable<SelectListItem> EmployeDesigSelectListItems
        {
            get { return new SelectList(Employeedesignations, "EmployeeDesignationId", "DesinationName"); }
        }


        public virtual IEnumerable<SelectListItem> GenderSelectListItems
        {

            get { return new SelectList(Genders, "GenderId", "Title"); }
        } 
    }
}