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
  public  class RowMeterialRpository :Repository<RowMatrial>,IRrowMeterialRepository
  {
      public RowMeterialRpository(DENTALERPDbContext context) : base(context)
      {
      }

      public List<RowMatrial> GetAllRowMeterial(out int totalrecords, RowMatrial model)
      {

          var index = model.PageIndex;
          var pageSize = AppConfig.PageSize;

          var rowMeterialList = Context.RowMatrials.Where(x => x.IsActive &&

                                                            (x.Name.Trim()
                                                                .ToLower()
                                                                .Contains(model.Name.Trim().ToLower()) ||
                                                             model.Name == null));

          totalrecords = rowMeterialList.Count();
          switch (model.Sort)
          {
              case "Name":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          rowMeterialList =
                              rowMeterialList.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          rowMeterialList =
                              rowMeterialList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "Cost":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          rowMeterialList =
                              rowMeterialList.OrderByDescending(p => p.Cost).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          rowMeterialList =
                              rowMeterialList.OrderBy(p => p.Cost).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "ManufacturingDate":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          rowMeterialList =
                              rowMeterialList.OrderByDescending(p => p.ManufacturingDate).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          rowMeterialList =
                              rowMeterialList.OrderBy(p => p.ManufacturingDate).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;






              default:
                  rowMeterialList =
                              rowMeterialList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                  break;
          }

          return rowMeterialList.ToList();
      }
  }
}
