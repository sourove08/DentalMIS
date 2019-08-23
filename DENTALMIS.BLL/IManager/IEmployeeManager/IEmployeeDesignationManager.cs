using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IEmployeeManager
{
   public interface IEmployeeDesignationManager
    {
       List<Employeedesignation> GetAllDesignationByPaging(out int totalrecord, Employeedesignation model);

       Employeedesignation GetDesignationById(int id);

       int Save(Employeedesignation empds);

       int Edit(Employeedesignation empds);

       int Delete(int id);

       List<Employeedesignation> GetAllDesignation();
    }
}
