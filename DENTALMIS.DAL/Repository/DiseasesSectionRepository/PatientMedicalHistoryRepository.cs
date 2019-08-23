using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DiseasesSectionRepository
{
   public class PatientMedicalHistoryRepository:Repository<PatientsMedicalHistory>,IPatientMedicalHistoryRepository
   {
       public PatientMedicalHistoryRepository(DENTALERPDbContext context) : base(context)
       {
       }


       public List<PatientsMedicalHistory> GetAllMedicalHistoriesByPaging(out int totalrecords, PatientsMedicalHistory model,int? patientId,int? diseasesId)
       {
           int pageindex = model.PageIndex;

           int pageSize = AppConfig.PageSize;

           var patientsMedicalHistories =
               Context.PatientsMedicalHistories.Include(x => x.Patient)
                   .Include(x => x.Disease)
                   .Where(x => x.IsActive == true
                               &&( x.Medicalhistory.Trim().ToLower().Contains(model.Medicalhistory.Trim().ToLower())|| model.Medicalhistory==null) &&
                               (x.PatientId == model.PatientId || model.PatientId == 0) &&(x.DiseasesId==model.DiseasesId||model.DiseasesId==0));

           totalrecords = patientsMedicalHistories.Count();

           switch (model.Sort)
           {
               case "Medicalhistory":

                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientsMedicalHistories = patientsMedicalHistories.OrderByDescending(x => x.Medicalhistory)
                                   .Skip(pageSize * pageindex)
                                   .Take(pageSize);
                           break;
                       default:
                           patientsMedicalHistories = patientsMedicalHistories.OrderBy(x => x.Medicalhistory)
                                .Skip(pageSize * pageindex)
                                .Take(pageSize);
                           break;
                   }
                   break;
               case "VitalSign":

                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientsMedicalHistories = patientsMedicalHistories.OrderByDescending(x => x.VitalSign)
                                   .Skip(pageSize * pageindex)
                                   .Take(pageSize);
                           break;
                       default:
                           patientsMedicalHistories = patientsMedicalHistories.OrderBy(x => x.VitalSign)
                                .Skip(pageSize * pageindex)
                                .Take(pageSize);
                           break;
                   }
                   break;
               case "PatientId":

                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientsMedicalHistories = patientsMedicalHistories.OrderByDescending(x => x.PatientId)
                                   .Skip(pageSize * pageindex)
                                   .Take(pageSize);
                           break;
                       default:
                           patientsMedicalHistories = patientsMedicalHistories.OrderBy(x => x.PatientId)
                                .Skip(pageSize * pageindex)
                                .Take(pageSize);
                           break;
                   }
                   break;
               default:
                   patientsMedicalHistories = patientsMedicalHistories.OrderBy(x => x.Medicalhistory)
                        .Skip(pageSize * pageindex)
                        .Take(pageSize);
                   break;
           }

           return patientsMedicalHistories.ToList();
       }

       public List<Patient> GetPatientbyDiseases(int diseasesId)
       {
           return Context.Patients.Where(x => x.DiseasesId == diseasesId && x.IsActive == true).ToList();
       }
   }
}
