using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IEmployeeRepository
{
  public  interface IEmployeeDesignationRepository :IRepository<Employeedesignation>
  {
      List<Employeedesignation> GetAllDesignationByPaging(out int totalrecord, Employeedesignation model);
  }
}
