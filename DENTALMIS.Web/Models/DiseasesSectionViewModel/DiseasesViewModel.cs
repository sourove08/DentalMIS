using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DiseasesSectionViewModel
{
    public class DiseasesViewModel:Disease
    {
        public DiseasesViewModel()
        {
            Diseases=new List<Disease>();
            DiseasesInvestigations=new List<DiseasesInvestigation>();
        }

        public List<Disease> Diseases { get; set; }

        public List<DiseasesInvestigation> DiseasesInvestigations { get; set; }

        public string SearchByDieasesName { get; set; }

        public IEnumerable<SelectListItem> DiseasescInvestigationSelectListItems
        {
            get { return new SelectList(DiseasesInvestigations, " DiseasesInvestigationId", "Name"); }
        } 
    }
}