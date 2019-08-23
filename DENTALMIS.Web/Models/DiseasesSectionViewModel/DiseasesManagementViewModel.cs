using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class DiseasesManagementViewModel :DiseasesManagement
    {
        public List<DiseasesManagement> DiseasesManagements { get; set; }
        public List<DisesesClinicalFeature> DisesesClinicalFeatures { get; set; }
        public List<DiseasesInvestigation> DiseasesInvestigations { get; set; }

        public List<Disease> DiseasesList { get; set; }

        public string SearchByDiseasesName { get; set; }
        public string SearchByManagementName { get; set; }


        public IEnumerable<SelectListItem> DiseaseSelectListItemsSelectListItems
        {
            get { return new SelectList(DiseasesList, "DiseasesId", "Name"); }
        }
        //public IEnumerable<SelectListItem> DismanagementliSelectListItems
        //{

        //    get { return new SelectList(DiseasesManagements, "DiseasesManagementId", "ManagementProcess"); }
        //}

      
        public IEnumerable<SelectListItem> DiseasescInvestigationSelectListItems
        {
            get { return new SelectList(DiseasesInvestigations, " DiseasesInvestigationId", "Name"); }

        }
        public IEnumerable<SelectListItem> DiseasesclinicalFeatureseSelectListItems
        {
            get { return new SelectList(DisesesClinicalFeatures, "ClinicalFeatureId", "Symptom"); }
        }
    }
}