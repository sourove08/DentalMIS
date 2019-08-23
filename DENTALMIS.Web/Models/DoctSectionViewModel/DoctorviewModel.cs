using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DoctSectionViewModel
{
    public class DoctorviewModel:Doctor
    {

        public List<Doctor> Doctors { get; set; }

        public List<DoctorsDesignation> DoctorsDesignations { get; set; }

        public List<Gender> Genders { get; set; }


        public DoctorviewModel()
        {
            
            Doctors=new List<Doctor>();

            DoctorsDesignations=new List<DoctorsDesignation>();

            Genders=new List<Gender>();
        }

        public string SearchbyName { get; set; }


        public string SearchByRegistrationNumber { get; set; }


        public virtual IEnumerable<SelectListItem> DoctorDesignationSelectListItems
        {

            get { return new SelectList(DoctorsDesignations, "DoctorDesignationId", "DesignationName"); }
        }
        public virtual IEnumerable<SelectListItem> GenderSelectListItems
        {

            get { return new SelectList(Genders, "GenderId", "Title"); }
        } 
    }
}