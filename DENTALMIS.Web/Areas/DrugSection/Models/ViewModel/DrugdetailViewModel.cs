using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Areas.DrugSection.Models.ViewModel
{
    public class DrugdetailViewModel:DrugDetail
    {
        public DrugdetailViewModel()
        {
            DrugGenerics=new List<DrugGeneric>();
            DrugDetails=new List<DrugDetail>();
        }

        public List<DrugDetail> DrugDetails { get; set; }

        public List<DrugGeneric> DrugGenerics { get; set; }


        public IEnumerable<SelectListItem> DrugGenericSelectListItems
        {
            get { return new SelectList(DrugGenerics, "GenericId", "Name"); }
        }


       
    }
}