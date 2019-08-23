using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
   public interface IPatientRepository:IRepository<Patient>
   {
       List<Patient> GetAllPatienByPaging(out int totalrecords, Patient model);

       List<Patient> GetPatientByDiseasesId(int diseasesId);

       Patient GetAllPatienByCode(string patientCode);
   }
}
