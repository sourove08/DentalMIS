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
    public class PatientViewModel:Patient
    {
        public List<Patient> Patients { get; set; }

        public List<Gender> Genders { get; set; }

        public List<Disease> Diseases { get; set; }
        public PatientViewModel()
        {
            Patients=new List<Patient>();
            Genders=new List<Gender>();
            Diseases=new List<Disease>();
        }

        public string SearchByName { get; set; }
        [DisplayName("From Date : ")]
        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }
            [DisplayName("To Date : ")]
         [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }
        //

           
        public override string Name { get; set; }

        public virtual IEnumerable<SelectListItem> DiseasesSelectListItems
        {
            get { return new SelectList(Diseases, "DiseasesId", "Name"); }
        }
        public IEnumerable<SelectListItem> GenderSelectListItems
        {
            get { return new SelectList(Genders,"GenderId","Title"); }
        } 
    }
}