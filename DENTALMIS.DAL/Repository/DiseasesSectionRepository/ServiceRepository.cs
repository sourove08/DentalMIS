using System.Collections.Generic;
using System.Linq;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DiseasesSectionRepository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(DENTALERPDbContext context) : base(context)
        {
        }

        public List<Service> GetAllByPaging(out int totalrecords, Service model)
        {
            int index = model.PageIndex;

            int pageSize = AppConfig.PageSize;

            var services =
                Context.Services.Where(
                    x =>
                        x.IsActive &&
                        (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null));

            totalrecords = services.Count();

            switch (model.Sort)
            {
                case "Name":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            services = services.OrderByDescending(r => r.Name).Skip(index*pageSize);
                            break;
                        default:
                            services = services.OrderBy(r => r.Name).Skip(index*pageSize);
                            break;
                    }
                    break;


                case "TreatmentCost":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            services = services.OrderByDescending(r => r.TreatmentCost).Skip(index*pageSize);
                            break;
                        default:
                            services = services.OrderBy(r => r.TreatmentCost).Skip(index*pageSize);
                            break;
                    }
                    break;
                case "TimesOfVisit":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            services = services.OrderByDescending(r => r.TimesOfVisit).Skip(index*pageSize);
                            break;
                        default:
                            services = services.OrderBy(r => r.TimesOfVisit).Skip(index*pageSize);
                            break;
                    }
                    break;
                default:
                    services = services.OrderBy(r => r.Name).Skip(index*pageSize);
                    break;



            }

            return services.ToList();
        }
    }
}
