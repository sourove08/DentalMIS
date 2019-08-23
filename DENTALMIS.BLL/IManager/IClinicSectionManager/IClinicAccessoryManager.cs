using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IClinicSectionManager
{
   public interface IClinicAccessoryManager
    {
       List<ClinicalAccessory> GetAllAccessoriesByPaging(out int totalrecords, ClinicalAccessory model);

       ClinicalAccessory GetAccessoriesById(int id);

       int Save(ClinicalAccessory clinicalAccessory);

       int Edit(ClinicalAccessory clinicalAccessory);

       int Delete(int id);
    }
}
