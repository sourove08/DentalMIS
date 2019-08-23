using System.Collections.Generic;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
   public interface IPatientMedicalHistoryRepository:IRepository<PatientsMedicalHistory>
   {

       List<PatientsMedicalHistory> GetAllMedicalHistoriesByPaging(out int totalrecords, PatientsMedicalHistory model ,int? patientId,int? diseasesId);

       List<Patient> GetPatientbyDiseases(int diseasesId);
   }
}
