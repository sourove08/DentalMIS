using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDiseasesSectionRepository;
using DENTALMIS.DAL.Repository.DiseasesSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DiseasesSectionManager
{
    public class PatientMedicalHistoryManager : IPatientMedicalHistoryManager
    {
        private IPatientMedicalHistoryRepository _patientMedicalHistoryRepository = null;


        public PatientMedicalHistoryManager(DENTALERPDbContext context)
        {
            _patientMedicalHistoryRepository = new PatientMedicalHistoryRepository(context);
        }


        public PatientsMedicalHistory GetHistorybyId(int patientHistoryId)
        {
            PatientsMedicalHistory patientsMedicalHistory;

            patientsMedicalHistory =
                _patientMedicalHistoryRepository.FindOne(x => x.PatientHistoryId == patientHistoryId);
            return patientsMedicalHistory;
        }

        public List<PatientsMedicalHistory> GetAllMedicalHistoriesByPaging(out int totalrecords, PatientsMedicalHistory model, int? patientId, int? diseasesId)
        {
            List<PatientsMedicalHistory> patientsMedicalHistories;

            try
            {
                patientsMedicalHistories =
                    _patientMedicalHistoryRepository.GetAllMedicalHistoriesByPaging(out totalrecords, model, patientId,diseasesId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }

            return patientsMedicalHistories;
        }

        public int DeleteHistory(int patientHistoryId)
        {
            int deleteIndex = 0;

            try
            {
                PatientsMedicalHistory patientsMedicalHistory = GetHistorybyId(patientHistoryId);
                patientsMedicalHistory.IsActive = false;
                deleteIndex = _patientMedicalHistoryRepository.Edit(patientsMedicalHistory);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return deleteIndex;
        }

        public int Save(PatientsMedicalHistory _patientsMedicalHistory)
        {
            int saveIndex = 0;
            try
            {
                _patientsMedicalHistory.IsActive = true;
                _patientsMedicalHistory.CreatedDate = DateTime.Now;
                saveIndex = _patientMedicalHistoryRepository.Save(_patientsMedicalHistory);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return saveIndex;

        }

        public int Edit(PatientsMedicalHistory _patientsMedicalHistory)
        {
            int editindex = 0;
            try
            {
                PatientsMedicalHistory patientsMedicalHistory = GetHistorybyId(_patientsMedicalHistory.PatientHistoryId);
                patientsMedicalHistory.PatientHistoryId = _patientsMedicalHistory.PatientHistoryId;
                patientsMedicalHistory.PatientId = _patientsMedicalHistory.PatientId;
                patientsMedicalHistory.DiseasesId = _patientsMedicalHistory.DiseasesId;
                patientsMedicalHistory.VitalSign = _patientsMedicalHistory.VitalSign;
                patientsMedicalHistory.Medicalhistory = _patientsMedicalHistory.Medicalhistory;

                patientsMedicalHistory.ModifiedDate = DateTime.Now;

                editindex = _patientMedicalHistoryRepository.Edit(patientsMedicalHistory);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return editindex;
        }

        public List<Patient> GetPatientbyDiseases(int diseasesId)
        {
            return _patientMedicalHistoryRepository.GetPatientbyDiseases(diseasesId).ToList();
        }
    }
}
