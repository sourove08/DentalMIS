using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IPatientRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.PatientRepository
{
   public class PatientSheduleRepository :Repository<PatientShedule>,IPatientSheduleRepository
   {
       public PatientSheduleRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<PatientShedule> GetAllPaging(out int totalrecords, PatientShedule model)
       {

           var index = model.PageIndex;
           var pageSize = AppConfig.PageSize;

           var shedulelist =
               Context.PatientShedules.Include(x => x.Patient)
                   .Where(x => x.PatientCode.Trim().ToLower().Contains(model.PatientCode.Trim().ToLower())||model.PatientCode==null);
             

           totalrecords = shedulelist.Count();
           switch (model.Sort)
           {
               case "PatientCode":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           shedulelist =
                               shedulelist.OrderByDescending(p => p.PatientCode).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           shedulelist =
                               shedulelist.OrderBy(p => p.PatientCode).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "VisitingTime":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           shedulelist =
                               shedulelist.OrderByDescending(p => p.VisitingTime).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           shedulelist =
                               shedulelist.OrderBy(p => p.VisitingTime).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "PatientId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           shedulelist =
                               shedulelist.OrderByDescending(p => p.PatientId).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           shedulelist =
                               shedulelist.OrderBy(p => p.PatientId).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
            



               default:
                   shedulelist =
                               shedulelist.OrderBy(p => p.PatientCode).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return shedulelist.ToList();
       }
   }
}
