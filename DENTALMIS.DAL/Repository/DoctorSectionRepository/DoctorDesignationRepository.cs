using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IDoctorSectionRepositoy;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DoctorSectionRepository
{
  public  class DoctorDesignationRepository :Repository<DoctorsDesignation>,IDoctorDesignationRepossitory
  {
      public DoctorDesignationRepository(DENTALERPDbContext context) : base(context)
      {
      }

      public List<DoctorsDesignation> GetAllDesignationByPaging(out int totalrecord, DoctorsDesignation model)
      {

          int pageIndex = model.PageIndex;

          int pageSize = AppConfig.PageSize;


          var doctorDesignation = Context.DoctorsDesignations.Where(x => x.IsActive == true);

          totalrecord = doctorDesignation.Count();

          switch (model.Sort)
          {
              case "DesignationName":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          doctorDesignation =
                              doctorDesignation.OrderByDescending(x => x.DesignationName).Skip(pageIndex*pageSize).Take(pageSize);
                          break;

                      default:
                           doctorDesignation =
                              doctorDesignation.OrderBy(x => x.DesignationName).Skip(pageIndex*pageSize).Take(pageSize);
                          break;

                  }
                  break;

              default:
                  doctorDesignation =
                     doctorDesignation.OrderBy(x => x.DesignationName).Skip(pageIndex * pageSize).Take(pageSize);
                  break;
          }
          return doctorDesignation.ToList();
      }
  }
}
