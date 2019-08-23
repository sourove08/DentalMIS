using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IClinicSectionRepository
{
   public interface IClinicAccessoryRepository : IRepository<ClinicalAccessory>
   {
       List<ClinicalAccessory> GetAllAccessoriesByPaging(out int totalrecords, ClinicalAccessory model);
   }
}
