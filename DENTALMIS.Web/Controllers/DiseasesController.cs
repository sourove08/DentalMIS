using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class DiseasesController : BaseController
    {
        public ActionResult Index(DiseasesViewModel model)
        {
            ModelState.Clear();
            var totalrecords = 0;
            model.Name = model.SearchByDieasesName;
            model.DiseasesInvestigations = DiseasesInvestigationManager.GetAllInvestigation();
            model.Diseases = DiseasesManager.GetAllDiseasesByPaging(out totalrecords, model);
            model.TotalRecords = totalrecords;
            return View(model);
        }

        public ActionResult Edit(DiseasesViewModel model)
        {
            ModelState.Clear();
            model.DiseasesInvestigations = DiseasesInvestigationManager.GetAllInvestigation();
            if (model.DiseasesId>0)
            {
                var disease = DiseasesManager.GetDeasesById(model.DiseasesId) ?? new Disease();
                model.DiseasesId = disease.DiseasesId;
                model.Name = disease.Name;
                model.Aetiology = disease.Aetiology;
                model.Pathophysiology = disease.Pathophysiology;
                model.DiseasesInvestigationId = disease.DiseasesInvestigationId;
            }
            return View(model);
        }

        public JsonResult Save(DiseasesViewModel model)
        {
            int saveIndex = 0;

            var _disease=new Disease();
            _disease.DiseasesId = model.DiseasesId;
            _disease.Name = model.Name;
            _disease.Aetiology = model.Aetiology;
            _disease.Pathophysiology = model.Pathophysiology;
            _disease.DiseasesInvestigationId = model.DiseasesInvestigationId;

            saveIndex = model.DiseasesId == 0 ? DiseasesManager.Save(_disease) : DiseasesManager.Edit(_disease);

          
            return Reload(saveIndex);
        }

        public JsonResult Delete(DiseasesViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = DiseasesManager.DeleteDiseases(model.DiseasesId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}