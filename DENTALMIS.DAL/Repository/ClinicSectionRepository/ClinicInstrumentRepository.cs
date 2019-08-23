using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IClinicSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.ClinicSectionRepository
{
   public class ClinicInstrumentRepository:Repository<ClinicalInstrument>,IClinicInstrumentRepository
   {
       public ClinicInstrumentRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<ClinicalInstrument> GetAllInstrumentByPaging(out int totalrecords, ClinicalInstrument model)
       {
           var index = model.PageIndex;
           var pageSize = AppConfig.PageSize;

           var clInsList = Context.ClinicalInstruments.Where(x => x.IsActive &&

                                                             (x.Name.Trim()
                                                                 .ToLower()
                                                                 .Contains(model.Name.Trim().ToLower()) ||
                                                              model.Name == null));

           totalrecords = clInsList.Count();
           switch (model.Sort)
           {
               case "Name":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           clInsList =
                               clInsList.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           clInsList =
                               clInsList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Description":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           clInsList =
                               clInsList.OrderByDescending(p => p.Description).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           clInsList =
                               clInsList.OrderBy(p => p.Description).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
             

                     



               default:
                   clInsList =
                               clInsList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return clInsList.ToList();
       }
   }
}
