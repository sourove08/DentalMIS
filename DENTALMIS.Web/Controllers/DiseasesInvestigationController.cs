using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class DiseasesInvestigationController : BaseController
    {
        public ActionResult Index(DiseasesInvestigationViewModel model)
        {
            ModelState.Clear();
            var totalrecords = 0;
            model.Name = model.SeacrhbyInvestigationName;
            model.DisesesClinicalFeatures = DiseasesClinicalFeatureManager.GetAllFeature();
            model.DiseasesInvestigations=DiseasesInvestigationManager.GetAllInvestigationByPaging(out totalrecords,model);
            model.TotalRecords = totalrecords;
            return View(model);
        }

        public ActionResult Edit(DiseasesInvestigationViewModel model)
        {
            ModelState.Clear();
            model.DisesesClinicalFeatures = DiseasesClinicalFeatureManager.GetAllFeature();
            if (model.DiseasesInvestigationId>0)
            {
                DiseasesInvestigation diseasesInvestigation = DiseasesInvestigationManager.GetInvestigationById(model.DiseasesInvestigationId) ??new DiseasesInvestigation();
                model.DiseasesInvestigationId = diseasesInvestigation.DiseasesInvestigationId;
                model.Name = diseasesInvestigation.Name;
                model.Result = diseasesInvestigation.Result;
                model.ClinicalFeatureId = diseasesInvestigation.ClinicalFeatureId;
            }
            return View(model);
        }

        public JsonResult Save(DiseasesInvestigationViewModel model)
        {
            int saveIndex = 0;
            var _dInv = new DiseasesInvestigation();
            _dInv.DiseasesInvestigationId = model.DiseasesInvestigationId;
            _dInv.Name = model.Name;
            _dInv.Result = model.Result;
            _dInv.ClinicalFeatureId = model.ClinicalFeatureId;
            saveIndex=model.DiseasesInvestigationId==0?DiseasesInvestigationManager.Save(_dInv):DiseasesInvestigationManager.Edit(_dInv);
            return Reload(saveIndex);
        }

        public JsonResult Delete(DiseasesInvestigationViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = DiseasesInvestigationManager.Delete(model.DiseasesInvestigationId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}