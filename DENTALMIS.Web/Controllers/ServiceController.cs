using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.ServiceSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class ServiceController : BaseController
    {

        public ActionResult Index(ServiceViewModel model)
        {
            ModelState.Clear();

            var totalrecords = 0;
            model.Services = ServiceManager.GetAllByPaging(out totalrecords, model);
            model.TotalRecords = totalrecords;
            return View(model);
        }
        public ActionResult Edit(ServiceViewModel model)
        {

            ModelState.Clear();
            if (model.ServiceId > 0)
            {
                var _service = ServiceManager.GetAllById(model.ServiceId);

                model.ServiceId = _service.ServiceId;
                model.Name = _service.Name;
                model.TreatmentCost = _service.TreatmentCost;
                model.TimesOfVisit = _service.TimesOfVisit;
            }
            return View(model);
        }
        public JsonResult Save(ServiceViewModel model)
        {
            int saveIndex = 0;
            Service _service = new Service();
            _service.ServiceId = model.ServiceId;
            _service.Name = model.Name;
            _service.TreatmentCost = model.TreatmentCost;
            _service.TimesOfVisit = model.TimesOfVisit;
            saveIndex = model.ServiceId == 0 ? ServiceManager.Save(_service) : ServiceManager.Edit(_service);
            return Reload(saveIndex);
        }
        public JsonResult Delete(ServiceViewModel model)
        {
            int deleteIndex = 0;


            try
            {
                deleteIndex = ServiceManager.DeleteService(model.ServiceId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed to Delete");
        }
	}
}