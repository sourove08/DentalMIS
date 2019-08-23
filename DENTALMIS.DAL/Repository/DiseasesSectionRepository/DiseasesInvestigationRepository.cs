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
    public class DiseasesInvestigationRepository : Repository<DiseasesInvestigation>, IDiseasesInvestigationRepository
    {
        public DiseasesInvestigationRepository(DENTALERPDbContext context)
            : base(context)
        {
        }

        public List<DiseasesInvestigation> GettAllInvestigationbyPaging(out int totalrecords, DiseasesInvestigation model)
        {
            var index = model.PageIndex;
            var pageSize = AppConfig.PageSize;

            var diseasesInvestigationList = Context.DiseasesInvestigations.Include(x => x.DisesesClinicalFeature).Where(x => x.IsActive &&

                (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null) && (x.ClinicalFeatureId == model.ClinicalFeatureId || model.ClinicalFeatureId == 0));

            totalrecords = diseasesInvestigationList.Count();
            switch (model.Sort)
            {
                case "Name":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            diseasesInvestigationList =
                                diseasesInvestigationList.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            diseasesInvestigationList =
                                diseasesInvestigationList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "Result":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            diseasesInvestigationList =
                                diseasesInvestigationList.OrderByDescending(p => p.Result).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            diseasesInvestigationList =
                                diseasesInvestigationList.OrderBy(p => p.Result).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "ClinicalFeatureId":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            diseasesInvestigationList =
                                diseasesInvestigationList.OrderByDescending(p => p.ClinicalFeatureId).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            diseasesInvestigationList =
                                diseasesInvestigationList.OrderBy(p => p.ClinicalFeatureId).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                default:
                    diseasesInvestigationList =
                                diseasesInvestigationList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                    break;
            }

            return diseasesInvestigationList.ToList();
        }
    }
}
