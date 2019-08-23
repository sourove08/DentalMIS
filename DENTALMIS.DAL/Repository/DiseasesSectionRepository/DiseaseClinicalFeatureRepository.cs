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
  public  class DiseaseClinicalFeatureRepository:Repository<DisesesClinicalFeature>,IDiseasesClinicalFeatureRepository
  {
      public DiseaseClinicalFeatureRepository(DENTALERPDbContext context) : base(context)
      {
      }

      public List<DisesesClinicalFeature> GetAllFeatureByPaging(out int totalrecords, DisesesClinicalFeature model)
      {
          var index = model.PageIndex;

          var pageSize = AppConfig.PageSize;

          var clinicalFeatureList =
              Context.DisesesClinicalFeatures.Where(
                  x => x.IsActive==true && (x.Symptom.Trim().ToLower().Contains(model.Symptom.Trim().ToLower())|| model.Symptom==null)&&(x.Sign.Trim().ToLower().Contains(model.Sign.Trim().ToLower())||model.Sign==null));
          totalrecords = clinicalFeatureList.Count();

          switch (model.Sort)
          {
              case "Sign":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          clinicalFeatureList =
                              clinicalFeatureList.OrderByDescending(x => x.Sign).Skip(index*pageSize).Take(pageSize);
                          break;
                      default:
                          clinicalFeatureList =
                              clinicalFeatureList.OrderBy(x => x.Sign).Skip(index*pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "Symptom":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          clinicalFeatureList =
                              clinicalFeatureList.OrderByDescending(x => x.Symptom).Skip(index * pageSize).Take(pageSize);
                          break;
                      default:
                          clinicalFeatureList =
                              clinicalFeatureList.OrderBy(x => x.Symptom).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              default:
                  clinicalFeatureList = clinicalFeatureList.OrderBy(x => x.Sign).Skip(index*pageSize).Take(pageSize);
                  break;
          }
          return clinicalFeatureList.ToList();
      }
  }
}
