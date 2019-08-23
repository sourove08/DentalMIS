using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.DoctSectionViewModel
{
    public class DoctorDesinationViewmodel:DoctorsDesignation
    {


        public List<DoctorsDesignation> DoctorsDesignations { get; set; }


        public DoctorDesinationViewmodel()
        {
            DoctorsDesignations=new List<DoctorsDesignation>();
        }
    }
}