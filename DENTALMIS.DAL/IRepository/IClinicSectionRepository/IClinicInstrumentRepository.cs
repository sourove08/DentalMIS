using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IClinicSectionRepository
{
   public interface IClinicInstrumentRepository :IRepository<ClinicalInstrument>
   {
       List<ClinicalInstrument> GetAllInstrumentByPaging(out int totalrecords, ClinicalInstrument model);
   }
}
