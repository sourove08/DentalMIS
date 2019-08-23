using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IClinicSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.ClinicSectionRepository
{
   public class ClinicDescrionRepossitory :Repository<ClincDescription>,IClinicDescriptionRepository
   {
       public ClinicDescrionRepossitory(DENTALERPDbContext context) : base(context)
       {
       }

       public List<ClincDescription> GetAllCDE(out int totalrecords, ClincDescription model)
       {
           var index = model.PageIndex;
           var pageSize = AppConfig.PageSize;

           var clList = Context.ClincDescriptions.Where(x => x.IsActive &&

                                                             (x.Name.Trim()
                                                                 .ToLower()
                                                                 .Contains(model.Name.Trim().ToLower()) ||
                                                              model.Name == null));

           totalrecords = clList.Count();
           switch (model.Sort)
           {
               case "Name":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           clList =
                               clList.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           clList =
                               clList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Address":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           clList =
                               clList.OrderByDescending(p => p.Address).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           clList =
                               clList.OrderBy(p => p.Address).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "websilte":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           clList =
                               clList.OrderByDescending(p => p.websilte).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           clList =
                               clList.OrderBy(p => p.websilte).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "ClinicMail":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           clList =
                               clList.OrderByDescending(p => p.ClinicMail).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           clList =
                               clList.OrderBy(p => p.ClinicMail).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
              break;



               default:
                   clList =
                               clList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return clList.ToList();
       }
   }
}
