using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DENTALMIS.BLL.IManager.IDrugSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository;
using DENTALMIS.DAL.IRepository.IDrugSectionRepository;
using DENTALMIS.DAL.Repository;
using DENTALMIS.DAL.Repository.DrugSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DrugSectionManager
{
  public  class DrugGenericManager:IDrugGenericManager
  {
      private IDrugGenericRepository _drugGenericRepository = null;


      public DrugGenericManager(DENTALERPDbContext context)
      {
          _drugGenericRepository=new DrugGenericRepository(context);
      }


      //public List<DrugGeneric> GetAllGenericDrug(int startPage, int _pageSize, out int totalRecords, DrugGeneric model)
      //{
      //     List<DrugGeneric> drugGenerics;

      //    try
      //    {
      //        drugGenerics = _drugGenericRepository.GetAllGenericDrug(startPage, _pageSize, out totalRecords, model);
      //    }
      //    catch (Exception exception)
      //    {
              
      //        throw new Exception(exception.Message);
      //    }

      //    return drugGenerics;
      //}
      public List<DrugGeneric> GetAllGenericDrug(out int totalRecords, DrugGeneric model)
      {
          List<DrugGeneric> drugGenerics;

          try
          {
              drugGenerics = _drugGenericRepository.GetAllGenericDrug( out totalRecords, model);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }

          return drugGenerics;
      }

      public DrugGeneric GetGenericDrugById(int genericId)
      {
          var _drugGeneric = new DrugGeneric();

          try
          {
              _drugGeneric = _drugGenericRepository.FindOne(x => x.GenericId == genericId);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return _drugGeneric;
      }

      public int SaveDrugGeneric(DrugGeneric _drugGeneric)
      {
          int saveIndex = 0;

          try
          {
              _drugGeneric.IsActive = true;
              saveIndex = _drugGenericRepository.Save(_drugGeneric);

          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int EditDrugGenerIc(DrugGeneric _drugGeneric)
      {
          int editIndex = 0;

          try
          {
              DrugGeneric drugGeneric = GetGenericDrugById(_drugGeneric.GenericId);
              drugGeneric.Name = _drugGeneric.Name;
              editIndex = _drugGenericRepository.Edit(drugGeneric);


          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int DeleteDrugGeneric(int genericId)
      {
          int deleteIndex = 0;

          try
          {
              var drugGeneric = GetGenericDrugById(genericId);
              drugGeneric.IsActive = false;
              deleteIndex = _drugGenericRepository.Edit(drugGeneric);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }

      public List<DrugGeneric> GettAllGenericDrug()
      {
          List<DrugGeneric> drugGenerics = null;

          try
          {
              drugGenerics = _drugGenericRepository.Filter(x => x.IsActive == true).ToList();
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return drugGenerics;
      }
  }
}
