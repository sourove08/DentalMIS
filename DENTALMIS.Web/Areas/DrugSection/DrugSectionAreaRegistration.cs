using System.Web.Mvc;

namespace DENTALMIS.Web.Areas.DrugSection
{
    public class DrugSectionAreaRegistration : AreaRegistration
    {


        public override string AreaName
        {
            get { return "DrugSection"; }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DrugSection_default",
                "DrugSection/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }

                );
        }
    }
}