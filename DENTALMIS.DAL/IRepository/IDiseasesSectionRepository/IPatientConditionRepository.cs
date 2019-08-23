using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
   public interface IPatientConditionRepository:IRepository<PatientCondition>
   {
       List<PatientCondition> GetAllPatientconditionByPaging(out int totalrecords, PatientCondition model);

       List<Patient> GetAllThePatientByDiseasesId(int diseasesId);
   }
}
