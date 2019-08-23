using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;
using DENTALMIS.Utility.HelperModel;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class PatientMedicalHistoryViewModel:PatientsMedicalHistory
    {
        public List<PatientsMedicalHistory> PatientsMedicalHistories { get; set; }

        public List<Patient> Patients { get; set; }

        public List<Disease> Diseases { get; set; }
        public SearchField SearchField { get; set; }

        public PatientMedicalHistoryViewModel()
        {
            Patients=new List<Patient>();
            PatientsMedicalHistories=new List<PatientsMedicalHistory>();
            Diseases=new List<Disease>();

            SearchField=new SearchField();
        }


        public virtual IEnumerable<SelectListItem> PatientSelectListItems
        {
            get { return new SelectList(Patients, "PatientId", "Name"); }
        }

        public virtual IEnumerable<SelectListItem> DiseasesSelectListItems
        {
            get { return new SelectList(Diseases, "DiseasesId", "Name"); }
        } 
    }
}