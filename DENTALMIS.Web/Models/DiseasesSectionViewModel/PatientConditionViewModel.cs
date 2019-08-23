using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class PatientConditionViewModel:PatientCondition
    {

        public List<PatientCondition> PatientConditions { get; set; }

        public List<Patient> Patients { get; set; }

        public List<Disease> Diseases { get; set; }

        public List<Service> Services { get; set; }


        public PatientConditionViewModel()
        {
            PatientConditions=new List<PatientCondition>();
            Patients=new List<Patient>();
            Diseases=new List<Disease>();
            Services=new List<Service>();
        }
        public virtual IEnumerable<SelectListItem> PatientSelectListItems
        {
            get { return new SelectList(Patients, "PatientId", "Name"); }
        }

        public virtual IEnumerable<SelectListItem> DiseasesSelectListItems
        {
            get { return new SelectList(Diseases, "DiseasesId", "Name"); }
        }

        public virtual IEnumerable<SelectListItem> ServiceSelectListItems
        {
            get { return new SelectList(Services, " ServiceId", "Name"); }
        } 
    }
}