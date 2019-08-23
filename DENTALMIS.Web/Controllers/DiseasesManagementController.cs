using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class DiseasesManagementController : BaseController
    {
        //
        // GET: /DiseasesManagement/
        public ActionResult Index(DiseasesManagementViewModel model)
        {
            ModelState.Clear();
            var totalrecords = 0;
            model.ManagementProcess = model.SearchByManagementName;
            model.DiseasesList = DiseasesManager.GetAllDiseases();
            model.DisesesClinicalFeatures = DiseasesClinicalFeatureManager.GetAllFeature();
            model.DiseasesInvestigations = DiseasesInvestigationManager.GetAllInvestigation();
            model.DiseasesManagements = DiseasesManagementManager.GetAllManagementByPaging(out totalrecords, model);
            model.TotalRecords = totalrecords;

            return View(model);
        }
        public ActionResult Edit(DiseasesManagementViewModel model)
        {
            ModelState.Clear();
            model.DiseasesList = DiseasesManager.GetAllDiseases();
            model.DisesesClinicalFeatures = DiseasesClinicalFeatureManager.GetAllFeature();
            model.DiseasesInvestigations = DiseasesInvestigationManager.GetAllInvestigation();
            if (model.DiseasesManagementId > 0)
            {
                var diseaseManagement = DiseasesManagementManager.GetDeasesManagementById(model.DiseasesManagementId) ?? new DiseasesManagement();
                model.DiseasesManagementId = diseaseManagement.DiseasesManagementId;
                model.ManagementProcess = diseaseManagement.ManagementProcess;
                model.Prognosis = diseaseManagement.Prognosis;
                model.DiseasesId = diseaseManagement.DiseasesId;
                model.ClinicalFeatureId = diseaseManagement.ClinicalFeatureId;
                model.DiseasesInvestigationId = diseaseManagement.DiseasesInvestigationId;


            }
            return View(model);
        }

        public JsonResult Save(DiseasesManagementViewModel model)
        {
            int saveIndex = 0;

            var _diseaseManagement = new DiseasesManagement();
            _diseaseManagement.DiseasesId = model.DiseasesId;
            _diseaseManagement.ManagementProcess = model.ManagementProcess;
            _diseaseManagement.Prognosis = model.Prognosis;
            _diseaseManagement.DiseasesManagementId = model.DiseasesManagementId;
            _diseaseManagement.ClinicalFeatureId = model.ClinicalFeatureId;
            _diseaseManagement.DiseasesInvestigationId = model.DiseasesInvestigationId;
            
           

            saveIndex = model.DiseasesManagementId == 0 ? DiseasesManagementManager.Save(_diseaseManagement) : DiseasesManagementManager.Edit(_diseaseManagement);


            return Reload(saveIndex);
        }

        public JsonResult Delete(DiseasesManagementViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = DiseasesManagementManager.Delete(model.DiseasesManagementId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}