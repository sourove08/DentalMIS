using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
  public  interface IPatientConditionManager
    {
      List<PatientCondition> GetAllPatientconditionByPaging(out int totalrecords, PatientCondition model);

      PatientCondition GetPatientconditionById(int patientConditionId);

      int Save(PatientCondition _patientCondition);

      int Edit(PatientCondition _patientCondition);

      int DeleteCondition(int patientConditionId);



      List<Patient> GetAllThePatientByDiseasesId(int diseasesId);
    }
}
