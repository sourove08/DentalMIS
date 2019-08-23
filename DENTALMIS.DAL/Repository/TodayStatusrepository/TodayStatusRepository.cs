using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.ITodaysStatussectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.TodayStatusrepository
{
  public  class TodayStatusRepository:Repository<TodaysPatientstatu>,ITodayStatusRepository
  {
      public TodayStatusRepository(DENTALERPDbContext context) : base(context)
      {
      }

      public List<TodaysPatientstatu> GetAllStatusByPaging(out int totalrecord, TodaysPatientstatu model)
      {
          int index = model.PageIndex;

          int pageSize = AppConfig.PageSize;

          var todayStatus =
              Context.TodaysPatientstatus.Where(
                  x => x.IsActive==true && (x.PatientName.Trim().ToLower().Contains(model.PatientName.Trim().ToLower()))||model.PatientName==null);
          totalrecord = todayStatus.Count();
          switch (model.Sort)
          {
              case "PatientName":

                  switch (model.SortDir)
                  {
                      case "DESC":
                          todayStatus = todayStatus.OrderByDescending(x => x.PatientName)
                                  .Skip(pageSize * index)
                                  .Take(pageSize);
                          break;
                      default:
                          todayStatus = todayStatus.OrderBy(x => x.PatientName)
                                  .Skip(pageSize * index)
                                  .Take(pageSize);
                          break;
                  }
                  break;
              case "SerialNo":

                  switch (model.SortDir)
                  {
                      case "DESC":
                          todayStatus = todayStatus.OrderByDescending(x => x.SerialNo)
                                  .Skip(pageSize * index)
                                  .Take(pageSize);
                          break;
                      default:
                          todayStatus = todayStatus.OrderBy(x => x.SerialNo)
                                  .Skip(pageSize * index)
                                  .Take(pageSize);
                          break;
                  }
                  break;
             
              default:
                  todayStatus = todayStatus.OrderBy(x => x.PatientName)
                       .Skip(pageSize * index)
                       .Take(pageSize);
                  break;
          }
          return todayStatus.ToList();


      }
  }
}
