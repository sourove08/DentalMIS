using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IEmployeeRepository
{
  public  interface IEmployeeRepository: IRepository<ClinicEmployee>
  {
      List<ClinicEmployee> GetAllEmployeeByPaging(out int totalrecords, ClinicEmployee model);
  }
}
