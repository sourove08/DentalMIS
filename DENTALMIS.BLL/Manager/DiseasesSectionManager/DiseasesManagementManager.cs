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
    public class DiseasesManagementManager : IDiseasesManagementManager
    {
        private IDiseasesManagementRepository _diseasesManagementRepository = null;


        public DiseasesManagementManager(DENTALERPDbContext context)
        {
            _diseasesManagementRepository = new DiseasesManagementRepository(context);
        }

        public List<DiseasesManagement> GetAllManagementByPaging(out int totalrecords, DiseasesManagement model)
        {
            List<DiseasesManagement> diseasesManagements;

            try
            {
                diseasesManagements = _diseasesManagementRepository.GetAllManagementByPaging(out totalrecords, model);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return diseasesManagements;
        }

        public DiseasesManagement GetDeasesManagementById(int diseasesManagementId)
        {
            DiseasesManagement diseasesManagement;

            try
            {
                diseasesManagement =
                    _diseasesManagementRepository.FindOne(x => x.DiseasesManagementId == diseasesManagementId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return diseasesManagement;
        }

        public int Save(DiseasesManagement _diseaseManagement)
        {
            int saveIndex = 0;
            try
            {
                _diseaseManagement.IsActive = true;
                saveIndex = _diseasesManagementRepository.Save(_diseaseManagement);

            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return saveIndex;
        }

        public int Edit(DiseasesManagement _diseaseManagement)
        {
            int editIndex = 0;
            try
            {
                DiseasesManagement diseasesManagement = GetDeasesManagementById(_diseaseManagement.DiseasesManagementId);
                diseasesManagement.ManagementProcess = _diseaseManagement.ManagementProcess;
                diseasesManagement.Prognosis = _diseaseManagement.Prognosis;
                diseasesManagement.DiseasesManagementId = _diseaseManagement.DiseasesManagementId;
                diseasesManagement.DiseasesId = _diseaseManagement.DiseasesId;
                diseasesManagement.ClinicalFeatureId = _diseaseManagement.ClinicalFeatureId;
                diseasesManagement.DiseasesInvestigationId = _diseaseManagement.DiseasesInvestigationId;
                editIndex = _diseasesManagementRepository.Edit(diseasesManagement);

            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return editIndex;
        }

        public int Delete(int diseasesManagementId)
        {
            int deleteIndex = 0;
            try
            {
                var _diseaseManagement = GetDeasesManagementById(diseasesManagementId);
                _diseaseManagement.IsActive = false;
                deleteIndex = _diseasesManagementRepository.Edit(_diseaseManagement);

            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex;
        }
    }
}

