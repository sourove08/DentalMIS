using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.BLL.Manager.DiseasesSectionManager
{
  public  class DiseasesInvestigationManager:IDiseasesInvestigationManager
  {
      private IDiseasesInvestigationRepository _diseasesInvestigationRepository = null;

      public DiseasesInvestigationManager(DENTALERPDbContext context)
      {
          _diseasesInvestigationRepository=new DiseasesInvestigationRepository(context);
      }

      public List<DiseasesInvestigation> GetAllInvestigationByPaging(out int totalrecords, DiseasesInvestigation model)
      {
          List<DiseasesInvestigation> _diseasesInvestigations;

          try
          {
              _diseasesInvestigations = _diseasesInvestigationRepository.GettAllInvestigationbyPaging(out totalrecords,
                  model);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return _diseasesInvestigations;

      }

      public DiseasesInvestigation GetInvestigationById(int diseasesInvestigationId)
      {
          DiseasesInvestigation diseasesInvestigation;
          try
          {
              diseasesInvestigation = _diseasesInvestigationRepository.FindOne(x => x.DiseasesInvestigationId == diseasesInvestigationId);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return diseasesInvestigation;

      }

      public int Save(DiseasesInvestigation _dInv)
      {
          int saveIndex = 0;
          try
          {
              _dInv.IsActive = true;
              saveIndex = _diseasesInvestigationRepository.Save(_dInv);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(DiseasesInvestigation _dInv)
      {
          int editIndex = 0;
          try
          {
              DiseasesInvestigation diseasesInvestigation = GetInvestigationById(_dInv.DiseasesInvestigationId);
              diseasesInvestigation.DiseasesInvestigationId = _dInv.DiseasesInvestigationId;
              diseasesInvestigation.Name = _dInv.Name;
              diseasesInvestigation.Result = _dInv.Result;
              diseasesInvestigation.ClinicalFeatureId = _dInv.ClinicalFeatureId;
              editIndex = _diseasesInvestigationRepository.Edit(diseasesInvestigation);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int Delete(int disesesInvestigationId)
      {
          int deleteIndex = 0;
          try
          {
              var diseasInvestigation = GetInvestigationById(disesesInvestigationId);
              diseasInvestigation.IsActive = false;
              deleteIndex = _diseasesInvestigationRepository.Edit(diseasInvestigation);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return deleteIndex;
      }

      public List<DiseasesInvestigation> GetAllInvestigation()
      {
          List<DiseasesInvestigation> diseasesInvestigations;
          try
          {
              diseasesInvestigations = _diseasesInvestigationRepository.Filter(x => x.IsActive == true).ToList();
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return diseasesInvestigations;
      }
  }
}
