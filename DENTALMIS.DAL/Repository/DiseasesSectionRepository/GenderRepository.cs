using System.Collections.Generic;
using System.Linq;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DiseasesSectionRepository
{
  public  class GenderRepository:Repository<Gender>,IGenderRepository
    {
      public GenderRepository(DENTALERPDbContext context) : base(context)
      {
      }

      public List<Gender> GetAllGender(out int totalrecords, Gender model)
      {
          int index = model.PageIndex;

          int pageSize = AppConfig.PageSize;
          var genders = Context.Genders.Where(x => x.IsActive &&
                                                   (x.Title.Trim().ToLower().Contains(model.Title.Trim().ToLower()) ||
                                                    model.Title == null));

          totalrecords = genders.Count();

          switch (model.Sort)
          {
              case "Title":
                  switch (model.SortDir)
                  {
                      case "DESC":
                          genders = genders.OrderByDescending(r => r.Title).Skip(index*pageSize);
                          break;
                      default:
                          genders = genders.OrderBy(r => r.Title).Skip(index*pageSize);
                          break;
                  }
                  break;
              default:
                  genders = genders.OrderBy(r => r.Title).Skip(index*pageSize);
                  break;

          }
          return genders.ToList();
      }
    }
}
