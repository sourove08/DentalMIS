using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DiseasesSectionRepository
{
   public class PatientConditionRepository:Repository<PatientCondition>,IPatientConditionRepository
   {
       public PatientConditionRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<PatientCondition> GetAllPatientconditionByPaging(out int totalrecords, PatientCondition model)
       {
           int index = model.PageIndex;

           int pageSize = AppConfig.PageSize;


           var patientConditions = Context.PatientConditions.Include(x => x.Patient).Include(x=>x.Disease).Include(x=>x.Service).Where(x => x.IsActive &&

               (x.PatienId == model.PatienId || model.PatienId == 0) && (x.DiseasesId == model.DiseasesId || model.DiseasesId == 0) && (x.ServiceId == model.ServiceId || model.ServiceId == 0));

           totalrecords = patientConditions.Count();
           switch (model.Sort)
           {
               case "Beforetreatment":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientConditions =
                               patientConditions.OrderByDescending(p => p.Beforetreatment).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patientConditions =
                               patientConditions.OrderBy(p => p.Beforetreatment).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "AfterTreatment":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientConditions =
                                patientConditions.OrderByDescending(p => p.AfterTreatment).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patientConditions =
                              patientConditions.OrderBy(p => p.AfterTreatment).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "PatienId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientConditions =
                                patientConditions.OrderByDescending(p => p.PatienId).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patientConditions =
                               patientConditions.OrderBy(p => p.PatienId).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "DiseasesId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientConditions =
                               patientConditions.OrderByDescending(p => p.DiseasesId).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patientConditions =
                               patientConditions.OrderBy(p => p.DiseasesId).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "ServiceId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientConditions =
                               patientConditions.OrderByDescending(p => p.ServiceId).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patientConditions =
                               patientConditions.OrderBy(p => p.ServiceId).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "CreatedDate":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientConditions =
                               patientConditions.OrderByDescending(p => p.Createddate).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patientConditions =
                               patientConditions.OrderBy(p => p.Createddate).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "ModifiedDate":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patientConditions =
                               patientConditions.OrderByDescending(p => p.ModifiedDate).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patientConditions =
                               patientConditions.OrderBy(p => p.ModifiedDate).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
              
               default:
                   patientConditions =
                               patientConditions.OrderBy(p => p.Beforetreatment).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return patientConditions.ToList();
       }

       public List<Patient> GetAllThePatientByDiseasesId(int diseasesId)
       {
           List<Patient> patients = null;

           patients = Context.Patients.Where(x => x.DiseasesId == diseasesId && x.IsActive == true).ToList();
           return patients;
       }
   }
}
