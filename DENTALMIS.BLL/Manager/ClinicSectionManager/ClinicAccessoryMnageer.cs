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
  public  class ClinicAccessoryMnageer:IClinicAccessoryManager
  {
      private IClinicAccessoryRepository _clinicAccessoryRepository = null;

      public ClinicAccessoryMnageer(DENTALERPDbContext context)
      {
          _clinicAccessoryRepository=new ClinicAccessoryRepository(context);
      }

      public List<ClinicalAccessory> GetAllAccessoriesByPaging(out int totalrecords, ClinicalAccessory model)
      {

          List<ClinicalAccessory> clinicalAccessories;
          try
          {
              clinicalAccessories = _clinicAccessoryRepository.GetAllAccessoriesByPaging(out totalrecords, model);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }

          return clinicalAccessories;
      }

      public ClinicalAccessory GetAccessoriesById(int id)
      {
                ClinicalAccessory clinicalAccessory;
          try
          {
              clinicalAccessory = _clinicAccessoryRepository.FindOne(x => x.AccessoriesId == id && x.IsActive == true);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
         return clinicalAccessory;
      }

      public int Save(ClinicalAccessory clinicalAccessory)
      {
          int saveIndex = 0;

          try
          {
              clinicalAccessory.IsActive = true;
              saveIndex = _clinicAccessoryRepository.Save(clinicalAccessory);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(ClinicalAccessory clinicalAccessory)
      {
          int editIndex = 0;
          try
          {
              ClinicalAccessory  _clinicalAccessory = GetAccessoriesById(clinicalAccessory.AccessoriesId);
              _clinicalAccessory.AccessoriesId = clinicalAccessory.AccessoriesId;
              _clinicalAccessory.Name = clinicalAccessory.Name;
              _clinicalAccessory.Purpose = clinicalAccessory.Purpose;
              _clinicalAccessory.MarketCost = clinicalAccessory.MarketCost;
              _clinicalAccessory.StockAmount = clinicalAccessory.StockAmount;

              editIndex = _clinicAccessoryRepository.Edit(_clinicalAccessory);
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
              ClinicalAccessory clinicalAccessory = GetAccessoriesById(id);

              clinicalAccessory.IsActive = false;

              deleteIndex = _clinicAccessoryRepository.Edit(clinicalAccessory);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }
  }
      }
 

