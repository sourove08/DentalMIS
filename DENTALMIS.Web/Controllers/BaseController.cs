using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.BLL.IManager.IClinicSectionManager;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.BLL.IManager.IDoctorSectionManager;
using DENTALMIS.BLL.IManager.IDrugSectionManager;
using DENTALMIS.BLL.IManager.IEmployeeManager;
using DENTALMIS.BLL.IManager.IPatientManager;
using DENTALMIS.BLL.IManager.IReportManager;
using DENTALMIS.BLL.IManager.ITodayStatusManager;
using DENTALMIS.BLL.Manager;
using log4net;

namespace DENTALMIS.Web.Controllers
{
    public abstract class BaseController : Controller
    {

        private readonly ILog _log = LogManager.GetLogger(typeof(BaseController));
        protected override void OnException(ExceptionContext filterContext)
        {
            _log.Error(filterContext.Exception + "\n" + Environment.StackTrace);
            base.OnException(filterContext);
            filterContext.ExceptionHandled = true;
        }

        #region Manager

        public Manager Manager
        {
            get { return Manager.Instance; }
        }
        #endregion
        #region Common

        public JsonResult CreateJsonResult(object data)
        {
            return new JsonResult { Data = data };

        }

        public JsonResult ErroResult(string message)
        {
            return Json(new
            {
                Success = false,
                Message = message

            }, JsonRequestBehavior.AllowGet);
        }

        internal List<string> CurrentErrors
        {
            get
            {
                return ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
        }

        public JsonResult ErrorResult()
        {
            return Json(new
            {
                Success = false,
                Errors = CurrentErrors
            });
        }

        public JsonResult ErroeMessageResult()
        {
            const string message = "Failed To Save Data :";
            return Json(new
            {
                Success = false,
                Message = message,
                Error = true
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Reload()
        {
           return Json(new { Success = true, Reload = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Reload(int saveStatus)
        {
            ;return saveStatus > 0 ? Json(new { Success = true, Reload = true }, JsonRequestBehavior.AllowGet):ErroResult("Failed to saved");
        }

        public ActionResult Dialog(object model)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }

            return View(model);
        }

        public ActionResult Dialog(string viewName, object model)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(viewName, model);
            }

            return View(viewName, model);
        }
        #endregion

        #region ManagerSection

        #region DrugManagerSection
        public IDrugGenericManager DrugGenericManager
        {
            get { return Manager.DrugGenericManager; }
        }

        public IDrugBrandManager DrugBrandManager
        {
            get { return Manager.DrugBrandManager; }
        }

        public IDrugDetailManager DrugDetailManager
        {
            get { return Manager.DrugDetailManager; }
        }
        #endregion

        #region DiseasesManagerSection

        public IDiseasesManager DiseasesManager
        {
            get { return Manager.DiseasesManager; }
        }

    
        public IDiseasesClinicalFeatureManager DiseasesClinicalFeatureManager
        {
            get {return Manager.DiseasesClinicalFeatureManager; }
        }

        public IDiseasesInvestigationManager DiseasesInvestigationManager
        {
            get { return Manager.DiseasesInvestigationManager; }
        }

        public IDiseasesManagementManager DiseasesManagementManager
        {
            get { return Manager.DiseasesManagementManager; }
        }
        #endregion

        #region Gender

        public IGenderManager GenderManager
        {
            get { return Manager.GenderManager; }
        }
        #endregion
        #region Service

        public IServiceManager ServiceManager
        {
            get { return Manager.ServiceManager; }
        }
        #endregion

        #region PatientSection

        public IPatientManager PatientManager
        {
            get { return Manager.PatientManager; }
        }

        public IPatientMedicalHistoryManager PatientMedicalHistoryManager
        {
            get { return Manager.PatientMedicalHistoryManager; }
        }

        public IPatientConditionManager PatientConditionManager
        {
            get { return Manager.PatientConditionManager; }
        }

        public IPaymentMethodManager PaymentMethodManager
        {
            get { return Manager.PaymentMethodManager; }
        }

        public IPatientSheduleManager PatientSheduleManager
        {
            get { return Manager.PatientSheduleManager; }
        }

        public IPatientManualShedulingManager PatientManualShedulingManager
        {
            get { return Manager.PatientManualShedulingManager; }
        }


        #endregion
        #region Status Section

        public ITodayStatusManager TodayStatusManager
        {
            get { return Manager.TodayStatusManager; }
        }
        #endregion
        #region DoctorSection

        public IDoctorManager DoctorManager
        {
            get { return Manager.DoctorManager; }
        }

        public IDoctorDesignationManager DoctorDesignationManager
        {
            get { return Manager.DoctorDesignationManager; }
        }
       
        #endregion
         #region EmployeeSection

        public IEmployeeManager EmployeeManager
        {
            get { return Manager.EmployeeManager; }
        }

        public IEmployeeDesignationManager EmployeeDesignationManager
        {
            get { return Manager.EmployeeDesignationManager; }
        }
       
        #endregion
        #region ClinicSection


        public IClinicDescriptionManager ClinicDescriptionManager
        {
            get { return Manager.ClinicDescriptionManager; }
        }


        public IClinicAccessoryManager ClinicAccessoryManager
        {
            get { return Manager.ClinicAccessoryManager; }
        }

        public IClinicInstrumentManager ClinicInstrumentManager
        {
            get { return Manager.ClinicInstrumentManager; }
        }


        public IRowMeterialManager RowMeterialManager
        {
            get { return Manager.RowMeterialManager; }
        }

        public IClinicAccountManager ClinicAccountManager
        {
            get { return Manager.ClinicAccountManager; }
        }

        public IClinicEstablishmentManager ClinicEstablishmentManager
        {
            get { return Manager.ClinicEstablishmentManager; }
        }

        #endregion



        #region Report

        public IReportManager ReportManager
        {
            get { return Manager.ReportManager; }
        }

        #endregion
        #endregion

    }
}