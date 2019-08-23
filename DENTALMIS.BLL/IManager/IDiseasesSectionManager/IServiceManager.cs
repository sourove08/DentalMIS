using System.Collections.Generic;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDiseasesSectionManager
{
  public  interface IServiceManager
    {

       List<Service> GetAllByPaging(out int totalrecords, Service model);

        Service GetAllById(int serviceId);

        int Save(Service _service);

        int Edit(Service _service);

        int DeleteService(int serviceId);

        

        List<Service> GetAllService();
    }
}
