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
   public class ClinicEsatblismentRepository :Repository<ClinicEstablishment>,ICliniEstablismentRepository
   {
       public ClinicEsatblismentRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<ClinicEstablishment> GetAllAByPaging(out int totalrecords, ClinicEstablishment model)
       {

           var index = model.PageIndex;
           var pageSize = AppConfig.PageSize;

           var cliesList = Context.ClinicEstablishments.Where(x => x.IsActive);

           //(x.Name.Trim()
           //    .ToLower()
           //    .Contains(model.Name.Trim().ToLower()) ||
           // model.Name == null));

           totalrecords = cliesList.Count();
           switch (model.Sort)
           {
               case "ClinicHouseCharge":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           cliesList =
                               cliesList.OrderByDescending(p => p.ClinicHouseCharge).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           cliesList =
                               cliesList.OrderBy(p => p.ClinicHouseCharge).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Date":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           cliesList =
                               cliesList.OrderByDescending(p => p.Date).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           cliesList =
                               cliesList.OrderBy(p => p.Date).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
             





               default:
                   cliesList =
                               cliesList.OrderBy(p => p.Date).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return cliesList.ToList();
       }

      
   }
}
