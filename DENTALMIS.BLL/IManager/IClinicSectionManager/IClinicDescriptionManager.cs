using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IClinicSectionManager
{
   public interface IClinicDescriptionManager
    {
       List<ClincDescription> GetAllCDE(out int totalrecords, ClincDescription model);

       ClincDescription GetClinicById(int id);

       int Save(ClincDescription cl);

       int Edit(ClincDescription cl);

       int Delete(int id);
    }
}
