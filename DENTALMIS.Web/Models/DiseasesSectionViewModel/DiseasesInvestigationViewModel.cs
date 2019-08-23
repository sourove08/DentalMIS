using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class DiseasesInvestigationViewModel:DiseasesInvestigation
    {
        public DiseasesInvestigationViewModel()
        {
            DiseasesInvestigations=new List<DiseasesInvestigation>();
            DisesesClinicalFeatures=new List<DisesesClinicalFeature>();
        }

        public List<DiseasesInvestigation> DiseasesInvestigations { get; set; }

        public List<DisesesClinicalFeature> DisesesClinicalFeatures { get; set; }


        public string SeacrhbyInvestigationName { get; set; }

        public IEnumerable<SelectListItem> DiseasesclinicalFeatureseSelectListItems
        {
            get { return new SelectList(DisesesClinicalFeatures,"ClinicalFeatureId","Symptom"); }
        } 


    }
}