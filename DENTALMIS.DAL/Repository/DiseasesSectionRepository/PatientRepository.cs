using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DiseasesSectionRepository
{
   public class PatientRepository:Repository<Patient>,IPatientRepository
   {
       public PatientRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<Patient> GetAllPatienByPaging(out int totalrecords, Patient model)
       {
           int index = model.PageIndex;

           int pageSize = AppConfig.PageSize;


           var patients = Context.Patients.Include(x => x.Gender).Include(x=>x.Disease).Where(x => x.IsActive &&

               (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null)  && (x.Contact == model.Contact || model.Contact==null)&&(x.DiseasesId == model.DiseasesId || model.DiseasesId==0));

           totalrecords = patients.Count();
           switch (model.Sort)
           {
               case "PatientCode":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patients =
                               patients.OrderByDescending(p => p.PatientCode).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patients =
                               patients.OrderBy(p => p.PatientCode).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Name":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patients =
                               patients.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patients =
                               patients.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Address":
                   switch (model.SortDir)
                   {
                       case "DESC":
                          patients=
                               patients.OrderByDescending(p => p.Address).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                            patients =
                               patients.OrderBy(p => p.Address).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Age":
                   switch (model.SortDir)
                   {
                       case "DESC":
                          patients =
                               patients.OrderByDescending(p => p.Age).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patients =
                               patients.OrderBy(p => p.Age).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Email":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patients =
                               patients.OrderByDescending(p => p.Email).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patients =
                               patients.OrderBy(p => p.Email).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "GenderId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           patients =
                               patients.OrderByDescending(p => p.GenderId).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           patients =
                               patients.OrderBy(p => p.GenderId).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               default:
                   patients =
                               patients.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return patients.ToList();
       }

       public List<Patient> GetPatientByDiseasesId(int diseasesId)
       {
           var patientlist =
               Context.Patients.Where(x => x.DiseasesId == diseasesId && x.IsActive == true)
                   .OrderBy(r => r.Name)
                   .ToList();

           return patientlist;
       }

       public Patient GetAllPatienByCode(string patientCode)
       {
           return Context.Patients.FirstOrDefault(x => x.PatientCode == patientCode && x.IsActive == true);
       }
   }
}
