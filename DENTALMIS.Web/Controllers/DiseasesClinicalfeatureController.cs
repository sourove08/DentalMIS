using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class DiseasesClinicalfeatureController : BaseController
    {
        public ActionResult Index(DiseasesClinicalFeatureViewModel model)
        {
            ModelState.Clear();

            var totalrecords = 0;
            model.Symptom = model.SearchBySymptom;
            model.Sign = model.SearchBySign;
            model.DisesesClinicalFeatures = DiseasesClinicalFeatureManager.GetAllFeatureByPaging(out totalrecords, model);
            model.TotalRecords = totalrecords;
            return View(model);
        }

        public ActionResult Edit(DiseasesClinicalFeatureViewModel model)
        {
            ModelState.Clear();
            if (model.ClinicalFeatureId>0)
            {
                var _clinicalFeature = DiseasesClinicalFeatureManager.GetFeatureById(model.ClinicalFeatureId) ??
                                       new DisesesClinicalFeature();

                model.ClinicalFeatureId = _clinicalFeature.ClinicalFeatureId;
                model.Symptom = _clinicalFeature.Symptom;
                model.Sign = _clinicalFeature.Sign;
            }
            return View(model);
        }

        public JsonResult Save(DiseasesClinicalFeatureViewModel model)
        {
            int saveIndex = 0;

            var _disesesClinicalFeature=new DisesesClinicalFeature();

            _disesesClinicalFeature.ClinicalFeatureId = model.ClinicalFeatureId;

            _disesesClinicalFeature.Symptom = model.Symptom;

            _disesesClinicalFeature.Sign = model.Sign;

            saveIndex=model.ClinicalFeatureId==0? DiseasesClinicalFeatureManager.Save(_disesesClinicalFeature):DiseasesClinicalFeatureManager.Edit(_disesesClinicalFeature);

            return Reload(saveIndex);
        }

        public JsonResult Delete(DiseasesClinicalFeatureViewModel model)
        {
            int deleteIndex = 0;

            try
            {
                deleteIndex = DiseasesClinicalFeatureManager.Delete(model.ClinicalFeatureId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
       
	}
}