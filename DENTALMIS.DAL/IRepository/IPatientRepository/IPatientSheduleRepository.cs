using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IPatientRepository
{
   public interface IPatientSheduleRepository:IRepository<PatientShedule>
   {
       List<PatientShedule> GetAllPaging(out int totalrecords, PatientShedule model);
   }
}
