using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IPatientRepository;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.Repository.PatientRepository
{
   public class PatientManualShedulingRepository :Repository<PatientShedule>,IPatientManualSedulingRepository
   {
       public PatientManualShedulingRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<string> GetPatientValue(string patientCode, DateTime date)
       {
           List<string> patientData=new List<string>();
           if (Context.Patients.Where(x=>x.PatientCode==patientCode).Count()!=1)
           {
               return null;
           }
           int patientId = Context.Patients.Where(x => x.PatientCode == patientCode).SingleOrDefault().PatientId;
           Patient patients = Context.Patients.Where(x => x.PatientId == patientId).SingleOrDefault();
           var gender = Context.Genders.Where(x => x.GenderId == patients.GenderId).SingleOrDefault().Title;
           var diseases = Context.Diseases.Where(x => x.DiseasesId == patients.DiseasesId).SingleOrDefault().Name;
           var name = Context.Patients.Where(x => x.PatientId == patientId).SingleOrDefault().Name;
           var contact= Context.Patients.Where(x => x.PatientId == patientId).SingleOrDefault().Contact;
           TimeSpan visitingTime=new TimeSpan();
           int Id = 0;
           var Purpose = "";
           patientData.Add(gender);
           patientData.Add(diseases);
           patientData.Add(name);
           patientData.Add(contact);
           patientData.Add(patientId.ToString());
           patientData.Add(visitingTime.ToString());
           patientData.Add(Id.ToString());
           patientData.Add(Purpose.ToString());
           return patientData;
       }
   }
}
