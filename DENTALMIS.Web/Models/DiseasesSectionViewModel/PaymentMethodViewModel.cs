using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class PaymentMethodViewModel:PaymentMethod
    {

        public List<Patient> Patients { get; set; }

        public List<Service> Services { get; set; }

        public List<PaymentMethod> PaymentMethods { get; set; }

        public PaymentMethodViewModel()
        {
            PaymentMethods=new List<PaymentMethod>();
            Patients=new List<Patient>();
            Services=new List<Service>();
        }
        public virtual IEnumerable<SelectListItem> PatientSelectListItems
        {
            get { return new SelectList(Patients, "PatientId", "Name"); }
        }

      
        public virtual IEnumerable<SelectListItem> ServiceSelectListItems
        {
            get { return new SelectList(Services, " ServiceId", "Name"); }
        }

        [DisplayName("From Date : ")]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
        [DisplayName("To Date : ")]
        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }

       

     
        

        


    }
}