using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Models.GenderSectionViewModel
{
    public class GenderViewModel:Gender
    {
        public List<Gender> Genders { get; set; }


        public GenderViewModel()
        {
            Genders=new List<Gender>();
        }
    }
}