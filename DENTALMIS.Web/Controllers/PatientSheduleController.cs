using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class PatientSheduleController : BaseController
    {
        //
        // GET: /PatientShedule/
        public ActionResult Index(PatientSheduleViewModel  model)
        {
            ModelState.Clear();
            var totalrecords = 0;
            model.PatientShedules = PatientSheduleManager.GetAllPaging(out totalrecords, model);
            //.Where(x => (x.Date >= model.FromDate || model.FromDate == null) && (x.Date <= model.ToDate || model.ToDate == null)).ToList(); ;
            model.TotalRecords = totalrecords;
            return View(model);

        }
	}
}