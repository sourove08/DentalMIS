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
  public  class DiseasesRepository:Repository<Disease>,IDiseasesRepository
  {
      public DiseasesRepository(DENTALERPDbContext context) : base(context)
      {
      }

      public List<Disease> GettAllDiseasesPaging(out int totalrecords, Disease model)
      {
          var index = model.PageIndex;
          var pageSize = AppConfig.PageSize;

          var diseasesList = Context.Diseases.Include(x => x.DiseasesInvestigation).Where(x => x.IsActive &&

              (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null) && (x.DiseasesInvestigationId == model.DiseasesInvestigationId || model.DiseasesInvestigationId == 0));

          totalrecords = diseasesList.Count();
          switch (model.Sort)
          {
              case "Name":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          diseasesList =
                              diseasesList.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          diseasesList =
                              diseasesList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "Aetiology":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          diseasesList =
                              diseasesList.OrderByDescending(p => p.Aetiology).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          diseasesList =
                              diseasesList.OrderBy(p => p.Aetiology).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "Pathophysiology":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          diseasesList =
                              diseasesList.OrderByDescending(p => p.Pathophysiology).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          diseasesList =
                              diseasesList.OrderBy(p => p.Pathophysiology).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "DiseasesInvestigationId":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          diseasesList =
                              diseasesList.OrderByDescending(p => p.DiseasesInvestigationId).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          diseasesList =
                              diseasesList.OrderBy(p => p.DiseasesInvestigationId).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              default:
                  diseasesList =
                              diseasesList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                  break;
          }

          return diseasesList.ToList();
      }
  }
}
