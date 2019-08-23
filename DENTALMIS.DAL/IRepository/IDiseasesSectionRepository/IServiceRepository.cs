using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDiseasesSectionRepository
{
   public interface IServiceRepository:IRepository<Service>
   {
       List<Service> GetAllByPaging(out int totalrecords, Service model);
   }
}
