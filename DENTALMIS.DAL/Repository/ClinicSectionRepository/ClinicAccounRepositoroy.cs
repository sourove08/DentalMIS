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
  public  class ClinicAccounRepositoroy :Repository<ClinicAccount>,IClinicAccountRepository
  {
      public ClinicAccounRepositoroy(DENTALERPDbContext context) : base(context)
      {
      }

      public List<ClinicAccount> GetAllAccountByPaging(out int totalrecords, ClinicAccount model)
      {
          var index = model.PageIndex;
          var pageSize = AppConfig.PageSize;

          var cliaccountList = Context.ClinicAccounts.Where(x => x.IsActive );

                                                            //(x.Name.Trim()
                                                            //    .ToLower()
                                                            //    .Contains(model.Name.Trim().ToLower()) ||
                                                            // model.Name == null));

          totalrecords = cliaccountList.Count();
          switch (model.Sort)
          {
              case "Income":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          cliaccountList =
                              cliaccountList.OrderByDescending(p => p.Income).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          cliaccountList =
                              cliaccountList.OrderBy(p => p.Income).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "OutCome":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          cliaccountList =
                              cliaccountList.OrderByDescending(p => p.OutCome).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          cliaccountList =
                              cliaccountList.OrderBy(p => p.OutCome).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "TotalIncome":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          cliaccountList =
                              cliaccountList.OrderByDescending(p => p.TotalIncome).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          cliaccountList =
                              cliaccountList.OrderBy(p => p.TotalIncome).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;






              default:
                  cliaccountList =
                              cliaccountList.OrderBy(p => p.TotalIncome).Skip(index * pageSize).Take(pageSize);
                  break;
          }

          return cliaccountList.ToList();
      }

    

      
  }
}
