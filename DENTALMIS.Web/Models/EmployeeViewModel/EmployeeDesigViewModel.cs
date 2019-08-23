using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.EmployeeViewModel
{
    public class EmployeeDesigViewModel:Employeedesignation
    {

        public List<Employeedesignation> Employeedesignations { get; set; }


        public EmployeeDesigViewModel()
        {
            
            Employeedesignations=new List<Employeedesignation>();
        }
    }
}