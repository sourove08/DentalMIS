using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Controllers
{
    public class PatientManualShedulingController : BaseController
    {
        //
        // GET: /PatientManualSheduling/
        public ActionResult Index()
        {
            List<string> hours=new List<string>();
            List<string> minutes=new List<string>();
            List<string> periods=new List<string>();
            hours.Add("Hour");
            minutes.Add("Minute");
            periods.Add("AM/PM");
            for (int i = 0; i <=12; i++)
            {
                if (i<10)
                 hours.Add("0"+i.ToString());
                else
                hours.Add(i.ToString());
            }
            for (int i = 0; i < 60; i++)
            {
                if (i<10)
                    minutes.Add("0"+i.ToString());
                else
                    minutes.Add(i.ToString());
            }
            periods.Add("AM");
            periods.Add("PM");
            ViewBag.Hours=new SelectList(hours.AsEnumerable());
            ViewBag.Minutes= new SelectList(minutes.AsEnumerable());
            ViewBag.Period = new SelectList(periods.AsEnumerable());
            return View();
        }

        public ActionResult GetPatientData(string patientCode, DateTime dt)
        {
            ////dt=new string();
            var value = true;
            //DateTime date = DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<string> patientData = PatientManualShedulingManager.GetPatientValue(patientCode, dt);
            if (patientData==null)
            {
                value = false;
            }
            return Json(new {data = patientData, Success = value});
        }
        public ActionResult SavePatientShedule(List<string> values )
        {
            TimeSpan ts=new TimeSpan();
            PatientShedule patientShedule=new PatientShedule();
            patientShedule.PatientCode = values[0];
            patientShedule.Date = DateTime.Now;
            patientShedule.VisitingTime = DateTime.ParseExact(values[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (values[2].Contains("Hour"))
                patientShedule.VisitingTime = patientShedule.VisitingTime + ts;
            else
                patientShedule.VisitingTime = patientShedule.VisitingTime + TimeSpan.Parse(values[2]);
            patientShedule.VisitingPurpose = values[3];
            patientShedule.PatientId = Convert.ToInt16(values[4]);
            patientShedule.Id = Convert.ToInt32(values[5]);
            patientShedule.Contact = values[6];
            patientShedule.serialNo = Convert.ToInt16(values[7]);
            patientShedule.PataientType = values[8];
            var message = PatientManualShedulingManager.SavePatientShedule(patientShedule);
            return Json(new { Success = true, Message = message });

        }
	}
}