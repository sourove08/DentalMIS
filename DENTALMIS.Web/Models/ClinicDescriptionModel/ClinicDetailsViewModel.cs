using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.ClinicDescriptionModel
{
    public class ClinicDetailsViewModel:ClincDescription
    {

        public List<ClincDescription> ClincDescriptions { get; set; }


        public ClinicDetailsViewModel()
        {
            ClincDescriptions=new List<ClincDescription>();
        }


        public string SearchByNamee { get; set; }

    }
}