using System.Collections.Generic;
using System.Web.Mvc;
using DENTALMIS.Model;

namespace DENTALMIS.Web.Areas.DrugSection.Models.ViewModel
{
    public class DrugGenericViewModel : DrugGeneric
    {
        public DrugGenericViewModel()
        {
            DrugGenerics=new List<DrugGeneric>();
        }

        public List<DrugGeneric> DrugGenerics { get; set; }

        public string SearchDrugGenericName { get; set; }

        public virtual IEnumerable<SelectListItem> DrugSelectListItems
        {
            get { return new SelectList(DrugGenerics, "GenericId", "Name"); }
        } 


    }
}