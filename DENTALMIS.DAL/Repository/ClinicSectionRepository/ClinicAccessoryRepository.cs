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
   public class ClinicAccessoryRepository :Repository<ClinicalAccessory>,IClinicAccessoryRepository
   {
       public ClinicAccessoryRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<ClinicalAccessory> GetAllAccessoriesByPaging(out int totalrecords, ClinicalAccessory model)
       {

           var index = model.PageIndex;
           var pageSize = AppConfig.PageSize;

           var clIAccesList = Context.ClinicalAccessories.Where(x => x.IsActive &&

                                                             (x.Name.Trim()
                                                                 .ToLower()
                                                                 .Contains(model.Name.Trim().ToLower()) ||
                                                              model.Name == null));

           totalrecords = clIAccesList.Count();
           switch (model.Sort)
           {
               case "Name":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           clIAccesList =
                               clIAccesList.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           clIAccesList =
                               clIAccesList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Description":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           clIAccesList =
                               clIAccesList.OrderByDescending(p => p.Purpose).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           clIAccesList =
                               clIAccesList.OrderBy(p => p.Purpose).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;






               default:
                   clIAccesList =
                               clIAccesList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return clIAccesList.ToList();
       }
   }
}
