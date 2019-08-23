using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IPatientRepository
{
   public interface IPatientManualSedulingRepository:IRepository<PatientShedule>
   {
       List<string> GetPatientValue(string patientCode, DateTime date);
   }
}
