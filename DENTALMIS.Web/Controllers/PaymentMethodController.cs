using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Web.Models.DiseasesSectionViewModel;

namespace DENTALMIS.Web.Controllers
{
    public class PaymentMethodController : BaseController
    {
        //
        // GET: /PaymentMethod/
        public ActionResult Index(PaymentMethodViewModel model)
        {

            model.Patients = PatientManager.GetAllPatient();
            model.Services = ServiceManager.GetAllService();
            var totalrecords = 0;
            model.PaymentMethods = PaymentMethodManager.GetAllPaymentbyPaging(out totalrecords, model).Where(x => (x.Date >= model.FromDate || model.FromDate == null) && (x.Date <= model.ToDate || model.ToDate == null)).ToList(); 
            model.TotalCharge = model.Charge - model.DiscountAmount;
            model.TotalRecords = totalrecords;

            return View(model);
        }

        public ActionResult Edit(PaymentMethodViewModel model)
        {
            model.Patients = PatientManager.GetAllPatient();
            model.Services = ServiceManager.GetAllService();

            if (model.PaymentMethodId>0)
            {
                var paymentMethod = PaymentMethodManager.GetPaymentbyId(model.PaymentMethodId);

                model.PaymentMethodId = paymentMethod.PaymentMethodId;
                model.PatientId = paymentMethod.PatientId;
                model.ServiceId = paymentMethod.ServiceId;
                model.DiscountAmount = paymentMethod.DiscountAmount;
                model.Charge = paymentMethod.Charge;
                model.TotalCharge = paymentMethod.TotalCharge;
              
                model.Paid = paymentMethod.Paid;
                model.Due =paymentMethod.Due;
                model.Date = paymentMethod.Date;
                model.PaymentType = paymentMethod.PaymentType;
                model.CreatedDate = paymentMethod.CreatedDate;
                model.LastPaidDate = paymentMethod.LastPaidDate;
            }
            return View(model);
        }

        public JsonResult Save(PaymentMethodViewModel model)
        {

            int saveIndex = 0;

            PaymentMethod paymentMethod=new PaymentMethod();
            paymentMethod.PaymentMethodId = model.PaymentMethodId;
            paymentMethod.ServiceId = model.ServiceId;
            paymentMethod.PatientId = model.PatientId;
            paymentMethod.Charge = model.Charge;
            paymentMethod.DiscountAmount = model.DiscountAmount;
            paymentMethod.Paid = model.Paid;
            paymentMethod.Date = model.Date;
            paymentMethod.PaymentType = model.PaymentType;
            paymentMethod.CreatedDate = model.CreatedDate;
            paymentMethod.LastPaidDate = model.LastPaidDate;
            paymentMethod.TotalCharge = paymentMethod.Charge - paymentMethod.DiscountAmount;
            paymentMethod.Due = paymentMethod.TotalCharge - paymentMethod.Paid;

            saveIndex = model.PaymentMethodId == 0
                ? PaymentMethodManager.Save(paymentMethod)
                : PaymentMethodManager.Edit(paymentMethod);


            




            return Reload(saveIndex);
        }

        public JsonResult Delete(PaymentMethodViewModel model)
        {
            int deleteIndex = 0;

            try
            {
                deleteIndex = PaymentMethodManager.Delete(model.PaymentMethodId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message);
            }
            return deleteIndex > 0 ? Reload() : ErroResult("Failed To Delete");
        }
	}
}