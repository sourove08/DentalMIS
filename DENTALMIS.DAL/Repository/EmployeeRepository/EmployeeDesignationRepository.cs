using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IEmployeeRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.EmployeeRepository
{
   public class EmployeeDesignationRepository:Repository<Employeedesignation>,IEmployeeDesignationRepository
   {
       public EmployeeDesignationRepository(DENTALERPDbContext context) : base(context)
       {
       }

       public List<Employeedesignation> GetAllDesignationByPaging(out int totalrecord, Employeedesignation model)
       {
           int pageIndex = model.PageIndex;

           int pageSize = AppConfig.PageSize;


           var empDes = Context.Employeedesignations.Where(x => x.IsActive == true);

           totalrecord = empDes.Count();

           switch (model.Sort)
           {
               case "DesinationName":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           empDes =
                               empDes.OrderByDescending(x => x.DesinationName).Skip(pageIndex * pageSize).Take(pageSize);
                           break;

                       default:
                           empDes =
                              empDes.OrderBy(x => x.DesinationName).Skip(pageIndex * pageSize).Take(pageSize);
                           break;

                   }
                   break;

               default:
                   empDes =
                      empDes.OrderBy(x => x.DesinationName).Skip(pageIndex * pageSize).Take(pageSize);
                   break;
           }
           return empDes.ToList();
       }
   }
}
