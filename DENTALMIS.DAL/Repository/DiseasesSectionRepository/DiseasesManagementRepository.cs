using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DiseasesSectionRepository
{
   public class DiseasesManagementRepository:Repository<DiseasesManagement>,IDiseasesManagementRepository
   {
       public DiseasesManagementRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<DiseasesManagement> GetAllManagementByPaging(out int totalrecords, DiseasesManagement model)
       {
           var index = model.PageIndex;
           var pageSize = AppConfig.PageSize;

           var diseasesManagementList = Context.DiseasesManagements.Include(x => x.Disease).Include(y=>y.DiseasesInvestigation).Include(r=>r.DisesesClinicalFeature).Where(x => x.IsActive &&

               (x.ManagementProcess.Trim().ToLower().Contains(model.ManagementProcess.Trim().ToLower()) || model.ManagementProcess == null) && (x.DiseasesId == model.DiseasesId || model.DiseasesId == 0) && (x.ClinicalFeatureId == model.ClinicalFeatureId || model.ClinicalFeatureId == 0) && (x.DiseasesInvestigationId == model.DiseasesInvestigationId || model.DiseasesInvestigationId == 0));

           totalrecords = diseasesManagementList.Count();
           switch (model.Sort)
           {
               case "ManagementProcess":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           diseasesManagementList =
                               diseasesManagementList.OrderByDescending(p => p.ManagementProcess).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           diseasesManagementList =
                               diseasesManagementList.OrderBy(p => p.ManagementProcess).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Prognosis":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           diseasesManagementList =
                               diseasesManagementList.OrderByDescending(p => p.Prognosis).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           diseasesManagementList =
                               diseasesManagementList.OrderBy(p => p.Prognosis).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "ClinicalFeatureId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           diseasesManagementList =
                               diseasesManagementList.OrderByDescending(p => p.ClinicalFeatureId).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           diseasesManagementList =
                               diseasesManagementList.OrderBy(p => p.ClinicalFeatureId).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "DiseasesInvestigationId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           diseasesManagementList =
                               diseasesManagementList.OrderByDescending(p => p.DiseasesInvestigationId).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           diseasesManagementList =
                               diseasesManagementList.OrderBy(p => p.DiseasesInvestigationId).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "DiseasesId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           diseasesManagementList =
                               diseasesManagementList.OrderByDescending(p => p.DiseasesId).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           diseasesManagementList =
                               diseasesManagementList.OrderBy(p => p.DiseasesId).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
            
               default:
                   diseasesManagementList =
                               diseasesManagementList.OrderBy(p => p.ManagementProcess).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return diseasesManagementList.ToList();
       }
   }
}
 