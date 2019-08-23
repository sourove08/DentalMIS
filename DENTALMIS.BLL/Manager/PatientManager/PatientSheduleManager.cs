using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IPatientManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IPatientRepository;
using DENTALMIS.DAL.Repository.PatientRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.PatientManager
{
  public  class PatientSheduleManager:IPatientSheduleManager
  {

      private IPatientSheduleRepository _patientSheduleRepository = null;

      public PatientSheduleManager(DENTALERPDbContext context)
      {
          _patientSheduleRepository=new PatientSheduleRepository(context);
      }


      public List<PatientShedule> GetAllPaging(out int totalrecords, PatientShedule model)
      {
          List<PatientShedule> patientShedules;

          try
          {
              patientShedules =
                  _patientSheduleRepository.GetAllPaging(out totalrecords, model);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }

          return patientShedules;
      }
  }
}
