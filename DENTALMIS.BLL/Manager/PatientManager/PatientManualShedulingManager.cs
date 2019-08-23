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
   public class PatientManualShedulingManager:IPatientManualShedulingManager
   {
       private IPatientManualSedulingRepository _patientManualSedulingRepository = null;


       public PatientManualShedulingManager(DENTALERPDbContext context)
       {
           _patientManualSedulingRepository=new PatientManualShedulingRepository(context);
       }

       public List<string> GetPatientValue(string patientCode, DateTime date)
       {
           return _patientManualSedulingRepository.GetPatientValue(patientCode, date);
       }

       public string SavePatientShedule(PatientShedule patientShedule)
       {
           var message = "";

           try
           {
             

               if (patientShedule.Id == 0)
                   message = _patientManualSedulingRepository.Save(patientShedule).ToString();
               else
                   message = _patientManualSedulingRepository.Edit(patientShedule).ToString();

               return message = "Data saved successfully !";
           }

           catch (Exception ex)
           {
               return message = "Error has created !";
           }
       }
   }
}
