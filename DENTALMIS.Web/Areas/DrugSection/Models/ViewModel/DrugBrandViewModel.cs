using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Areas.DrugSection.Models.ViewModel
{
    public class DrugBrandViewModel:DrugBrand
    {
        public DrugBrandViewModel()
        {
            DrugBrands=new List<DrugBrand>();
            DrugGenerics = new List<DrugGeneric>();
        }

        public List<DrugBrand> DrugBrands { get; set; }
        public List<DrugGeneric> DrugGenerics { get; set; }

        public string SeachByBrandName { get; set; }
        public int SearchByGenericDSrug { get; set; }

        public int SearchByDrugBrand { set; get; }

        //public List<DrugGeneric> SeachByGenericName { get; set; }

        public virtual IEnumerable<SelectListItem> DruggenericSelectListItems
        {
            get { return new SelectList(DrugGenerics, "GenericId", "Name"); }
        }
        public virtual IEnumerable<SelectListItem> DrugBrandSelectListItems
        {
            get { return new SelectList(DrugBrands, "BrandId", "Name"); }
        }


        public string SearchKey { get; set; }

        


    }
}