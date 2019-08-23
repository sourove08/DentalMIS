using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.ReportViewModel
{
    public class DynamicReportHeaderViewModel : PaymentMethod
    {

        public List<PaymentMethod> PaymentMethods { set; get; }


        public List<Patient> Patients { get; set; }



        public DynamicReportHeaderViewModel()
        {
            PaymentMethods = new List<PaymentMethod>();

            Patients = new List<Patient>();
        }

        public IEnumerable<SelectListItem> PatientSelectListItems
        {
            get { return new SelectList(Patients, "PatientId", "PatientCode"); }
        }
        [Required(ErrorMessage = "Required")]
        public string PatientCode { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required")]
        public DateTime? FromDate { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required")]
        public DateTime? ToDate { get; set; }

    }
}