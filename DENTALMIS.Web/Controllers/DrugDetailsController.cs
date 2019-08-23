using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.BLL.Manager.DrugSectionManager;
using DENTALMIS.Model;
using DENTALMIS.Web.Areas.DrugSection.Models.ViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class DrugDetailsController : BaseController
    {

        public ActionResult Index(DrugdetailViewModel model)
        {
            ModelState.Clear();
            var totalrecords = 0;
            model.DrugGenerics = DrugGenericManager.GettAllGenericDrug();
            model.DrugDetails = DrugDetailManager.GetAllDrugDetails(out totalrecords, model);
            model.TotalRecords = totalrecords;
            return View(model);





        }

        public ActionResult Edit(DrugdetailViewModel model)
        {
            ModelState.Clear();

            model.DrugGenerics = DrugGenericManager.GettAllGenericDrug();
            if (model.DrugDetailId>0)
            {
                var _drugDetails = DrugDetailManager.GetDrugDeatilsbyId(model.DrugDetailId) ?? new DrugDetail();

                model.DrugDetailId = _drugDetails.DrugDetailId;
                model.Indication = _drugDetails.Indication;
                model.Dosage = _drugDetails.Dosage;

                model.Contraindication = _drugDetails.Contraindication;
                model.SideEffect = _drugDetails.SideEffect;
                model.UseInPregnency = _drugDetails.UseInPregnency;
                model.UseInLactation = _drugDetails.UseInLactation;
                model.DrugInteraction = _drugDetails.DrugInteraction;
                model.Precaution = _drugDetails.DrugInteraction;
                model.Mechanism = _drugDetails.Mechanism;
                model.GenericId = _drugDetails.GenericId;
            }
            return View(model);
        }

        public JsonResult Save(DrugdetailViewModel model)
        {
            int saveIndex = 0;

            var _drugDetails = new DrugDetail();

            _drugDetails.DrugDetailId = model.DrugDetailId;
            _drugDetails.Indication = model.Indication;
            _drugDetails.Dosage = model.Dosage;

            _drugDetails.Contraindication = model.Contraindication;
            _drugDetails.SideEffect = model.SideEffect;
            _drugDetails.UseInPregnency = model.UseInPregnency;
            _drugDetails.UseInLactation = model.UseInLactation;
            _drugDetails.DrugInteraction = model.DrugInteraction;
            _drugDetails.Precaution = model.Precaution;
            _drugDetails.Mechanism = model.Mechanism;
            _drugDetails.GenericId = model.GenericId;

            saveIndex = model.DrugDetailId == 0 ? DrugDetailManager.SaveDrugDetail(_drugDetails) : DrugDetailManager.EditDrugdetail(_drugDetails);
            return Reload(saveIndex);

        }
        public JsonResult Delete(DrugdetailViewModel model)
        {
            int deleteIndex = 0;

            try
            {
                deleteIndex = DrugDetailManager.DeletedrugDetail(model.DrugDetailId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
    }
}