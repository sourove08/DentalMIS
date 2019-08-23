using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IClinicSectionManager
{
  public  interface IClinicEstablishmentManager
    {
      List<ClinicEstablishment> GetAllAByPaging(out int totalrecords, ClinicEstablishment model);

      ClinicEstablishment GetById(int id);

      int Save(ClinicEstablishment clesEstablishment);

      int Edit(ClinicEstablishment clesEstablishment);

      int Delete(int id);

      
    }
}
