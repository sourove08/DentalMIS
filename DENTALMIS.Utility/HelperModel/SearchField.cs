using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DENTALMIS.Utility.HelperModel
{
   public class SearchField :SearchModel<SearchField>
   {
       public virtual DateTime? StartDate { get; set; }

       public virtual DateTime? EndDate { get; set; }
       //[Required]
       public int SearchByDiseasesId { get; set; }

    }
}
