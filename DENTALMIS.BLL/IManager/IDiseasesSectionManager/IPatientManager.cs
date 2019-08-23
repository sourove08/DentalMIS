using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
   public interface IPatientManager
    {
       List<Patient> GetAllPatienByPaging(out int totalrecords, Patient model);

       Patient GetAllPatienById(int patientId);

       int Save(Patient _patient);

       int Edit(Patient _patient);

       int DeletePatient(int patientId);

       bool CheckExistingPatient(Patient patient);

       List<Patient> GetAllPatient();

       List<Patient> GetPatientByDiseasesId(int id);

       Patient GetAllPatienByCode(string patientCode);
    }
}
