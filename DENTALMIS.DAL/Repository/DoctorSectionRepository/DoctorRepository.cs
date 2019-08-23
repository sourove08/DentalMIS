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
  public  class DoctorRepository:Repository<Doctor>,IDoctorRepository
  {
      public DoctorRepository(DENTALERPDbContext context) : base(context)
      {
      }

      public List<Doctor> GetAllDoctorByPaging(out int totalrecords, Doctor model)
      {
          var index = model.PageIndex;
          var pageSize = AppConfig.PageSize;

          //var doctorList =
          //    Context.Doctors.Include(x => x.Gender).Include(y => y.DoctorsDesignation).Where(x => x.IsActive == true );

          var doctorList = Context.Doctors.Include(x => x.DoctorsDesignation).Include(x=>x.Gender).Where(x => x.IsActive &&

              (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null)&&(x.RegistrationNo.Contains(model.RegistrationNo)|| model.RegistrationNo==null) && (x.GenderId == model.GenderId || model.GenderId == 0) && (x.DessignationId == model.DessignationId || model.DessignationId == 0));

          totalrecords = doctorList.Count();
          switch (model.Sort)
          {
              case "Name":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          doctorList =
                              doctorList.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          doctorList =
                              doctorList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "RegistrationNo":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          doctorList =
                              doctorList.OrderByDescending(p => p.RegistrationNo).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          doctorList =
                              doctorList.OrderBy(p => p.RegistrationNo).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "Contact":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          doctorList =
                              doctorList.OrderByDescending(p => p.Contact).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          doctorList =
                              doctorList.OrderBy(p => p.Contact).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "Email":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          doctorList =
                              doctorList.OrderByDescending(p => p.Email).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          doctorList =
                              doctorList.OrderBy(p => p.Email).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "DessignationId":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          doctorList =
                              doctorList.OrderByDescending(p => p.DessignationId).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          doctorList =
                              doctorList.OrderBy(p => p.DessignationId).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;
              case "GenderId":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          doctorList =
                              doctorList.OrderByDescending(p => p.GenderId).Skip(index * pageSize).Take(pageSize);
                          break;

                      default:
                          doctorList =
                              doctorList.OrderBy(p => p.GenderId).Skip(index * pageSize).Take(pageSize);
                          break;
                  }
                  break;


              default:
                  doctorList =
                              doctorList.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                  break;
          }

          return doctorList.ToList();
      }
  }
}
