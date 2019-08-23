using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IClinicSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IClinicSectionRepository;
using DENTALMIS.DAL.Repository.ClinicSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.ClinicSectionManager
{
  public  class ClinicDescriptionManager:IClinicDescriptionManager
  {

      private IClinicDescriptionRepository _clinicDescriptionRepository = null;


      public ClinicDescriptionManager(DENTALERPDbContext context)
      {
          _clinicDescriptionRepository=new ClinicDescrionRepossitory(context);
      }

      public List<ClincDescription> GetAllCDE(out int totalrecords, ClincDescription model)
      {
          List<ClincDescription> clincDescriptions;

          try
          {
              clincDescriptions = _clinicDescriptionRepository.GetAllCDE(out totalrecords, model);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return clincDescriptions;

      }

      public ClincDescription GetClinicById(int id)
      {
          ClincDescription cl;
          try
          {
              cl = _clinicDescriptionRepository.FindOne(x => x.ClinicDescriptionId == id && x.IsActive == true);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return cl;
      }

      public int Save(ClincDescription cl)
      {
          int saveIndex = 0;
          try
          {
              cl.IsActive = true;
              saveIndex = _clinicDescriptionRepository.Save(cl);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(ClincDescription cl)
      {
          int editIndex = 0;
          try
          {
              ClincDescription _cl = GetClinicById(cl.ClinicDescriptionId);
              _cl.ClinicDescriptionId = cl.ClinicDescriptionId;
              _cl.Name = cl.Name;
              _cl.ClinicType = cl.ClinicType;
              _cl.ClinicContact = cl.ClinicContact;
              _cl.Address = cl.Address;
              _cl.ClinicMail = cl.ClinicMail;
              _cl.websilte = cl.websilte;
              editIndex = _clinicDescriptionRepository.Edit(_cl);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int Delete(int id)
      {
          int deleteIndex = 0;
          try
          {
              ClincDescription clinic = GetClinicById(id);
              clinic.IsActive =false;
              deleteIndex = _clinicDescriptionRepository.Edit(clinic);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }
  }
}
