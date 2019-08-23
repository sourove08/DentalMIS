using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IDrugSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DrugSectionRepository
{
    public class DrugDetailRepository : Repository<DrugDetail>, IDrugDetailRepository
    {
        public DrugDetailRepository(DENTALERPDbContext context)
            : base(context)
        {
        }

        public List<DrugDetail> GetAlldrugDetails(out int totalrecords, DrugDetail model)
        {
            var index = model.PageIndex;
            var pageSize = AppConfig.PageSize;

            var drugDetailsList =
                Context.DrugDetails.Include(x => x.DrugGeneric)
                    .Where(x => x.IsActive && (x.GenericId == model.GenericId || model.GenericId == 0));
            totalrecords = drugDetailsList.Count();
            switch (model.Sort)
            
      
            {
                case "Indication":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.Indication).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.Indication).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "Dosage":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.Dosage).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.Dosage).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "Contraindication":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.Contraindication).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.Contraindication).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "UseInPregnency":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.UseInPregnency).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.UseInPregnency).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "UseInLactation":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.UseInLactation).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.UseInLactation).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "DrugInteraction":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.DrugInteraction).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.DrugInteraction).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
              
                case "Precaution":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.Precaution).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.Precaution).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "Mechanism":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.Mechanism).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.Mechanism).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;
                case "GenericId":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugDetailsList =
                                drugDetailsList.OrderByDescending(p => p.DrugGeneric.Name).Skip(index * pageSize).Take(pageSize);
                            break;

                        default:
                            drugDetailsList =
                                drugDetailsList.OrderBy(p => p.DrugGeneric.Name).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;

                default:
                    drugDetailsList = drugDetailsList.OrderBy(p => p.Indication).Skip(index * pageSize).Take(pageSize);
                    break;
            }
            return drugDetailsList.ToList();
        }
    }
}
