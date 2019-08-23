using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IEmployeeRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.EmployeeRepository
{
   public class EmployeeRepository:Repository<ClinicEmployee>,IEmployeeRepository
   {
       public EmployeeRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<ClinicEmployee> GetAllEmployeeByPaging(out int totalrecords, ClinicEmployee model)
       {
            var index = model.PageIndex;
          var pageSize = AppConfig.PageSize;

          var employeeList = Context.ClinicEmployees.Include(x => x.Employeedesignation).Include(x=>x.Gender).Where(x => x.IsActive &&

              (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null) && (x.GenderId == model.GenderId || model.GenderId == 0) && (x.EmployeeDesignationId == model.EmployeeDesignationId || model.EmployeeDesignationId == 0));

          totalrecords = employeeList.Count();
          switch (model.Sort)
          {
              case "Name":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          employeeList =
                              employeeList.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          employeeList =
                              employeeList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "GenderId":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          employeeList =
                              employeeList.OrderByDescending(p => p.GenderId).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          employeeList =
                              employeeList.OrderBy(p => p.GenderId).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "Contact":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          employeeList =
                              employeeList.OrderByDescending(p => p.Contact).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          employeeList =
                              employeeList.OrderBy(p => p.Contact).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "Email":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          employeeList =
                              employeeList.OrderByDescending(p => p.Email).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          employeeList =
                              employeeList.OrderBy(p => p.Email).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "EmployeeDesignationId":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          employeeList =
                              employeeList.OrderByDescending(p => p.EmployeeDesignationId).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          employeeList =
                              employeeList.OrderBy(p => p.EmployeeDesignationId).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
            


              default:
                  employeeList =
                              employeeList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                  break;
          }

          return employeeList.ToList();
      }
       }
   }

