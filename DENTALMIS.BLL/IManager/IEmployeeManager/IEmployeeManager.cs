using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IEmployeeManager
{
   public interface IEmployeeManager
    {
       List<ClinicEmployee> GetAllEmployeeByPaging(out int totalrecords, ClinicEmployee model);

       ClinicEmployee GetEmployeeById(int id);

       int Save(ClinicEmployee _employee);

       int Edit(ClinicEmployee _employee);

       int Delete(int id);

     
    }
}
