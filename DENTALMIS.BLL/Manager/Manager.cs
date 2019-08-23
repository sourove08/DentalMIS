using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DENTALMIS.BLL.IManager.IClinicSectionManager;
using DENTALMIS.BLL.IManager.IDiseasesSectionManager;
using DENTALMIS.BLL.IManager.IDoctorSectionManager;
using DENTALMIS.BLL.IManager.IDrugSectionManager;
using DENTALMIS.BLL.IManager.IEmployeeManager;
using DENTALMIS.BLL.IManager.IPatientManager;
using DENTALMIS.BLL.IManager.IReportManager;
using DENTALMIS.BLL.IManager.ITodayStatusManager;
using DENTALMIS.BLL.Manager.ClinicSectionManager;
using DENTALMIS.BLL.Manager.DiseasesSectionManager;
using DENTALMIS.BLL.Manager.DoctorSectionManager;
using DENTALMIS.BLL.Manager.DrugSectionManager;
using DENTALMIS.BLL.Manager.EmployeeManager;
using DENTALMIS.BLL.Manager.PatientManager;
using DENTALMIS.BLL.Manager.TodaystatusManager;
using DENTALMIS.DAL;

namespace DENTALMIS.BLL.Manager
{
    public class Manager
    {
        #region Manager
        internal DENTALERPDbContext Context;

        public static Manager Instance
        {
            get
            {
                var manager = (Manager)HttpContext.Current.Items["DatabaseMange"];
                if (manager == null)
                {
                    manager = new Manager();
                    HttpContext.Current.Items["DatabaseMnanger"] = manager;
                }

                return manager;

            }
        }

        public Manager()
        {
            Context = new DENTALERPDbContext();
        }
        #endregion



        #region DrugSection
        private IDrugGenericManager _drugGenericManager;

        public IDrugGenericManager DrugGenericManager
        {
            get { return _drugGenericManager ?? (_drugGenericManager = new DrugGenericManager(Context)); }
        }

        private IDrugBrandManager _drugBrandManager;

        public IDrugBrandManager DrugBrandManager
        {
            get { return _drugBrandManager ?? (_drugBrandManager = new DrugBrandManager(Context)); }
        }

        private IDrugDetailManager _drugDetailManager;

        public IDrugDetailManager DrugDetailManager
        {
            get { return _drugDetailManager ?? (_drugDetailManager = new DrugDetailManager(Context)); }
        }
        #endregion

        #region DiseasesSection

        private IDiseasesManager _diseasesManager;

        public IDiseasesManager DiseasesManager
        {
            get { return _diseasesManager ?? (_diseasesManager = new DiseasesManager(Context)); }
        }



        private IDiseasesClinicalFeatureManager _diseasesClinicalFeatureManager;

        public IDiseasesClinicalFeatureManager DiseasesClinicalFeatureManager
        {
            get
            {
                return _diseasesClinicalFeatureManager ??
                       (_diseasesClinicalFeatureManager = new DiseasesClinicalFeatureManager(Context));
            }
        }

        private IDiseasesInvestigationManager _diseasesInvestigationManager;

        public IDiseasesInvestigationManager DiseasesInvestigationManager
        {
            get
            {
                return _diseasesInvestigationManager ??
                       (_diseasesInvestigationManager = new DiseasesInvestigationManager(Context));
            }
        }

        private IDiseasesManagementManager _diseasesManagementManager;

        public IDiseasesManagementManager DiseasesManagementManager
        {
            get
            {
                return _diseasesManagementManager ??
                       (_diseasesManagementManager = new DiseasesManagementManager(Context));
            }
        }

        #endregion

        #region Service

        private IServiceManager _serviceManager;

        public IServiceManager ServiceManager
        {
            get { return _serviceManager ?? (_serviceManager = new ServiceManager(Context)); }
        }

        #endregion

        #region Gender

        private IGenderManager _genderManager;

        public IGenderManager GenderManager
        {
            get { return _genderManager ?? (_genderManager = new GenderManager(Context)); }
        }

        #endregion

        #region PatientSection

        private IPatientManager _patientManager;

        public IPatientManager PatientManager
        {
            get { return _patientManager ?? (_patientManager = new DiseasesSectionManager.PatientManager(Context)); }
        }
        private IPatientMedicalHistoryManager _patientMedicalHistoryManager;

        public IPatientMedicalHistoryManager PatientMedicalHistoryManager
        {
            get
            {
                return _patientMedicalHistoryManager ??
                       (_patientMedicalHistoryManager = new PatientMedicalHistoryManager(Context));
            }
        }

        private IPaymentMethodManager _paymentMethodManager;

        public IPaymentMethodManager PaymentMethodManager
        {
            get { return _paymentMethodManager ?? (_paymentMethodManager = new PaymentMethodManager(Context)); }
        }

        private IPatientConditionManager _patientConditionManager;


        public IPatientConditionManager PatientConditionManager
        {
            get
            {
                return _patientConditionManager ?? (_patientConditionManager = new PatientConditionManager(Context));
            }
        }

        private IPatientSheduleManager _patientSheduleManager;

        public IPatientSheduleManager PatientSheduleManager
        {
            get { return _patientSheduleManager ?? (_patientSheduleManager = new PatientSheduleManager(Context)); }
        }
        private IPatientManualShedulingManager _patientManualShedulingManager;

        public IPatientManualShedulingManager PatientManualShedulingManager
        {
            get { return _patientManualShedulingManager ?? (_patientManualShedulingManager = new PatientManualShedulingManager(Context)); }
        }



        #endregion

        #region StatusSectio

        private ITodayStatusManager _todayStatusManager;

        public ITodayStatusManager TodayStatusManager
        {
            get { return _todayStatusManager ?? (_todayStatusManager = new TodayStatusManager(Context)); }
        }

        #endregion
        #region Doctor

        private IDoctorManager _doctorManager;

        public IDoctorManager DoctorManager
        {
            get { return _doctorManager ?? (_doctorManager = new DoctorManager(Context)); }
        }

        private IDoctorDesignationManager _doctorDesignationManager;


        public IDoctorDesignationManager DoctorDesignationManager
        {
            get
            {
                return _doctorDesignationManager ?? (_doctorDesignationManager = new DoctorDesignationManager(Context));
            }
        }

        #endregion
        #region Employee

        private IEmployeeManager _employeeManager;


        public IEmployeeManager EmployeeManager
        {
            get { return _employeeManager ?? (_employeeManager = new EmployeeManager.EmployeeManager(Context)); }
        }

        private IEmployeeDesignationManager _employeeDesignationManager;

        public IEmployeeDesignationManager EmployeeDesignationManager
        {
            get
            {
                return _employeeDesignationManager ?? (_employeeDesignationManager = new EmployeeDesignationManager(Context));
            }
        }


        #endregion
        #region ClinicSection
        private IClinicDescriptionManager _clinicDescriptionManager;
        public IClinicDescriptionManager ClinicDescriptionManager
        {
            get
            {
                return _clinicDescriptionManager ?? (_clinicDescriptionManager = new ClinicDescriptionManager(Context));
            }
        }
        private IClinicAccessoryManager _clinicAccessoryManager;
        public IClinicAccessoryManager ClinicAccessoryManager
        {
            get { return _clinicAccessoryManager ?? (_clinicAccessoryManager = new ClinicAccessoryMnageer(Context)); }
        }
        private IClinicInstrumentManager _clinicInstrumentManager;
        public IClinicInstrumentManager ClinicInstrumentManager
        {
            get { return _clinicInstrumentManager ?? (_clinicInstrumentManager = new ClinicInstrumentManager(Context)); }
        }
        private IRowMeterialManager _rowMeterialManager;
        public IRowMeterialManager RowMeterialManager
        {
            get { return _rowMeterialManager ?? (_rowMeterialManager = new RowMeterialManager(Context)); }
        }
        private IClinicAccountManager _clinicAccountManager;
        public IClinicAccountManager ClinicAccountManager
        {
            get { return _clinicAccountManager ?? (_clinicAccountManager = new ClinicAccountManager(Context)); }
        }
        private IClinicEstablishmentManager _clinicEstablishmentManager;
        public IClinicEstablishmentManager _ClinicEstablishmentManager;
        public IClinicEstablishmentManager ClinicEstablishmentManager
        {
            get
            {
                return _ClinicEstablishmentManager ??
                       (_ClinicEstablishmentManager = new ClinicEstablishmentManager(Context));
            }
        }
        #endregion
          #region report

        public IReportManager _ReportManager;

        public IReportManager ReportManager
        {
            get { return _ReportManager ?? (_ReportManager = new ReportManager.ReportManager(Context)); }
        }

        #endregion
    }
  
}
