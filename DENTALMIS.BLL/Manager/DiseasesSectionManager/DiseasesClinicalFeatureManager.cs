using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DiseasesSectionManager
{
  public  class DiseasesClinicalFeatureManager:IDiseasesClinicalFeatureManager
  {
      private IDiseasesClinicalFeatureRepository _diseasesClinicalFeatureRepository = null;


      public DiseasesClinicalFeatureManager(DENTALERPDbContext context)
      {
          _diseasesClinicalFeatureRepository=new DiseaseClinicalFeatureRepository(context);
      }

      public List<DisesesClinicalFeature> GetAllFeatureByPaging(out int totalrecords, DisesesClinicalFeature model)
      {
          List<DisesesClinicalFeature> disesesClinicalFeatures;

          try
          {
              disesesClinicalFeatures = _diseasesClinicalFeatureRepository.GetAllFeatureByPaging(out totalrecords, model);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return disesesClinicalFeatures;
      }

      public DisesesClinicalFeature GetFeatureById(int clinicalFeatureId)
      {
          var _disesesClinicalFeature=new DisesesClinicalFeature();
          try
          {
              _disesesClinicalFeature =
                  _diseasesClinicalFeatureRepository.FindOne(x => x.ClinicalFeatureId == clinicalFeatureId);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return _disesesClinicalFeature;
      }

      public int Save(DisesesClinicalFeature _disesesClinicalFeature)
      {
          int saveIndex = 0;
          try
          {
              _disesesClinicalFeature.IsActive = true;
              saveIndex = _diseasesClinicalFeatureRepository.Save(_disesesClinicalFeature);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(DisesesClinicalFeature _disesesClinicalFeature)
      {
          int editIndex = 0;
          try
          {
              DisesesClinicalFeature disesesClinicalFeature = GetFeatureById(_disesesClinicalFeature.ClinicalFeatureId);

              disesesClinicalFeature.ClinicalFeatureId = _disesesClinicalFeature.ClinicalFeatureId;
              disesesClinicalFeature.Symptom = _disesesClinicalFeature.Symptom;
              disesesClinicalFeature.Sign = _disesesClinicalFeature.Sign;
              editIndex = _diseasesClinicalFeatureRepository.Edit(disesesClinicalFeature);


          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int Delete(int clinicalfeatureId)
      {
          int deleteIndex = 0;
          try
          {
              var _diseasesClinicalFeature = GetFeatureById(clinicalfeatureId);
              _diseasesClinicalFeature.IsActive = false;
              deleteIndex = _diseasesClinicalFeatureRepository.Edit(_diseasesClinicalFeature);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }

      public List<DisesesClinicalFeature> GetAllFeature()
      {
          List<DisesesClinicalFeature> _disesesClinicalFeatures=null;

          try
          {
              _disesesClinicalFeatures = _diseasesClinicalFeatureRepository.Filter(x => x.IsActive == true).ToList();
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return _disesesClinicalFeatures;
      }
  }
}
