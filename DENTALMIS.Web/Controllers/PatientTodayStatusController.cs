using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class PatientTodayStatusController : BaseController
    {
        //
        // GET: /PatientTodayStatus/
        public ActionResult Index(TodayPatientStatusViewModel model )
        {
            ModelState.Clear();
            var totalrecord = 0;
            model.PatientName = model.SearchByName;

            model.TodaysPatientstatus = TodayStatusManager.GetAllStatusByPaging(out totalrecord, model);
            model.TotalRecords = totalrecord;
            return View(model);
        }

        public ActionResult Edit(TodayPatientStatusViewModel model)
        {
            //List<string> hours = new List<string>();
            //List<string> minutes = new List<string>();
            //List<string> period = new List<string>();

            //hours.Add("Hour");
            //minutes.Add("Minute");
            //period.Add("AM/PM");

            //for (int i = 0; i <= 12; i++)
            //{
            //    if (i < 10)
            //        hours.Add("0" + i.ToString());
            //    else
            //        hours.Add(i.ToString());
            //}

            //for (int i = 0; i < 60; i++)
            //{
            //    if (i < 10)
            //        minutes.Add("0" + i.ToString());
            //    else
            //        minutes.Add(i.ToString());
            //}

            //period.Add("AM");
            //period.Add("PM");

            //ViewBag.Hours = new SelectList(hours.AsEnumerable());
            //ViewBag.minutes = new SelectList(minutes.AsEnumerable());
            //ViewBag.period = new SelectList(period.AsEnumerable());


            if (model.Id>0)
            {
                var todaysPatientstatu = TodayStatusManager.GetStatusById(model.Id)?? new TodaysPatientstatu();

                model.Id = todaysPatientstatu.Id;
                model.PatientName = todaysPatientstatu.PatientName;
                model.PatientStatus = todaysPatientstatu.PatientStatus;
                model.SerialNo = todaysPatientstatu.SerialNo;
                model.VisitingDate = todaysPatientstatu.VisitingDate;
                //ViewBag.visitingtime = DateTime.Today.Add(todaysPatientstatu.visitingtime).ToString("hh:mm tt");
                //model.InTime = DateTime.Today.Add(todaysPatientstatu.visitingtime).ToString("hh:mm tt");
                model.visitingtime = todaysPatientstatu.visitingtime;
                model.contact = todaysPatientstatu.contact;
                model.VisitingPurpose = todaysPatientstatu.VisitingPurpose;
            }

            return View(model);
        }
        public JsonResult Save(TodayPatientStatusViewModel model)
        {
            int saveIndex = 0;
            TodaysPatientstatu todaysPatientstatu = new TodaysPatientstatu();

            TimeSpan ts = new TimeSpan();
            List<string> Values = new List<string>();


            

            todaysPatientstatu.Id = model.Id;
            todaysPatientstatu.PatientName = model.PatientName;
            todaysPatientstatu.PatientStatus = model.PatientStatus;
            todaysPatientstatu.SerialNo = model.SerialNo;
            todaysPatientstatu.VisitingDate = model.VisitingDate;
            //todaysPatientstatu.visitingtime = DateTime.ParseExact(model., "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;
            todaysPatientstatu.visitingtime = model.visitingtime;



            //if (Values.Contains("Hour"))
            //    model.InTime = model.InTime + ts;
            //else
            //    model.InTime = model.InTime + TimeSpan.Parse(model.Values);
            //todaysPatientstatu.visitingtime = DateTime.ParseExact(model.InTime, "h:mm tt", CultureInfo.InvariantCulture).TimeOfDay;



            ////if (Values[2].Contains("Hour"))
            ////    todaysPatientstatu.visitingtime = todaysPatientstatu.visitingtime + ts;
            ////else
            ////    todaysPatientstatu.visitingtime = todaysPatientstatu.visitingtime + TimeSpan.Parse(Values[1]);
            ////    //todaysPatientstatu.visitingtime = todaysPatientstatu.visitingtime + TimeSpan.Parse(model.ToString());

            todaysPatientstatu.contact = model.contact;
            todaysPatientstatu.VisitingPurpose = model.VisitingPurpose;
            saveIndex = model.Id == 0
                ? TodayStatusManager.Save(todaysPatientstatu)
                : TodayStatusManager.Edit(todaysPatientstatu);
            return Reload(saveIndex);
        }
        public JsonResult Delete(TodayPatientStatusViewModel model)
        {
            int deleteIndex = 0;
            try
            {
                deleteIndex = TodayStatusManager.Delete(model.Id);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To save");
        }
	}
}