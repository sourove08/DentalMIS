using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
    public interface IPatientMedicalHistoryManager
    {






        PatientsMedicalHistory GetHistorybyId(int patientHistoryId);

        List<PatientsMedicalHistory> GetAllMedicalHistoriesByPaging(out int totalrecords, PatientsMedicalHistory model,int? patientId,int? diseasesId);

        int DeleteHistory(int patientHistoryId);

        int Save(PatientsMedicalHistory _patientsMedicalHistory);

        int Edit(PatientsMedicalHistory _patientsMedicalHistory);

        List<Patient> GetPatientbyDiseases(int diseasesId);
    }
}
