using System;
using System.Collections.Generic;
using System.Linq;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DiseasesSectionManager
{
  public  class ServiceManager:IServiceManager
  {

      private IServiceRepository _serviceRepository = null;

      public ServiceManager(DENTALERPDbContext context)
      {
          _serviceRepository = new ServiceRepository(context);
      }

      public List<Service> GetAllByPaging(out int totalrecords, Service model)
      {
          List<Service> services;

          try
          {
              services = _serviceRepository.GetAllByPaging(out totalrecords, model);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return services;
      }

      public Service GetAllById(int serviceId)
      {
          Service service = new Service();

          try
          {
              service = _serviceRepository.FindOne(x => x.ServiceId == serviceId);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return service;
      }

      public int Save(Service _service)
      {
          int saveIndex = 0;
          try
          {
              _service.IsActive = true;
              saveIndex = _serviceRepository.Save(_service);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(Service _service)
      {
          int editIndex = 0;
          try
          {
              Service service = GetAllById(_service.ServiceId);
              service.ServiceId = _service.ServiceId;
              service.Name = _service.Name;
              service.TreatmentCost = _service.TreatmentCost;
              service.TimesOfVisit = _service.TimesOfVisit;
              editIndex = _serviceRepository.Edit(service);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int DeleteService(int serviceId)
      {
          int deleteIndex = 0;
          try
          {
              Service service = GetAllById(serviceId);
              service.IsActive = false;
              deleteIndex = _serviceRepository.Delete(service);

          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }

      public List<Service> GetAllService()
      {
          List<Service> services;

          try
          {
              services = _serviceRepository.Filter(x => x.IsActive == true).ToList();
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return services;
      }
  }
}
