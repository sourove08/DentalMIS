using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DoctSectionViewModel;
using DENTALMIS.Web.Models.EmployeeViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class EmployeeDesignationController : BaseController
    {
        //
        // GET: /EmployeeDesignation/
        public ActionResult Index(EmployeeDesigViewModel model)
        {
            ModelState.Clear();
            var totalrecord = 0;

            model.Employeedesignations = EmployeeDesignationManager.GetAllDesignationByPaging(out totalrecord, model);
            model.TotalRecords = totalrecord;

            return View(model);
        }

        public ActionResult Edit(EmployeeDesigViewModel model)
        {


            if (model.EmployeeDesignationId > 0)
            {
                Employeedesignation empdes = EmployeeDesignationManager.GetDesignationById(model.EmployeeDesignationId);
                    

                model.EmployeeDesignationId = empdes.EmployeeDesignationId;
                model.DesinationName = empdes.DesinationName;
              

            }
            return View(model);
        }
        public JsonResult Save(EmployeeDesigViewModel model)
        {
            int saveIndex = 0;

            Employeedesignation empds = new Employeedesignation();

            empds.EmployeeDesignationId = model.EmployeeDesignationId;
            empds.DesinationName = model.DesinationName;
           

            saveIndex = model.EmployeeDesignationId == 0
                ? EmployeeDesignationManager.Save(empds)
                : EmployeeDesignationManager.Edit(empds);

            return Reload(saveIndex);
        }
        public JsonResult Delete(EmployeeDesigViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = EmployeeDesignationManager.Delete(model.EmployeeDesignationId);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }


            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}