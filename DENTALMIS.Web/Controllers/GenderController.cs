using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.GenderSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class GenderController : BaseController
    {
        //
        // GET: /Gender/
        public ActionResult Index(GenderViewModel model)
        {
            ModelState.Clear();

            var totalrecords = 0;
            model.Genders = GenderManager.GetAllGender(out totalrecords, model);

            model.TotalRecords = totalrecords;
            return View(model);


        }

        public ActionResult Edit(GenderViewModel model)
        {
            ModelState.Clear();
            if (model.GenderId>0)
            {
                var _gender = GenderManager.GetGenderById(model.GenderId);

                model.GenderId = _gender.GenderId;
                model.Title = _gender.Title;

            }
            return View(model);
        }

        public JsonResult Save(GenderViewModel model)
        {
            int saveIndex = 0;

            Gender _gender=new Gender();
            _gender.GenderId = model.GenderId;
            _gender.Title = model.Title;
            saveIndex = model.GenderId == 0 ? GenderManager.Save(_gender) : GenderManager.Edit(_gender);
            return Reload(saveIndex);
        }

        public JsonResult Delete(GenderViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = GenderManager.DeleteGender(model.GenderId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }

            return deleteIndex > 0 ? Reload() : ErroResult("Failed to Delete");
        }
	}
}