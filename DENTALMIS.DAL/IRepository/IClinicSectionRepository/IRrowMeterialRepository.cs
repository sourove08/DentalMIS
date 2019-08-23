using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IClinicSectionRepository
{
  public  interface IRrowMeterialRepository :IRepository<RowMatrial>
  {
      List<RowMatrial> GetAllRowMeterial(out int totalrecords, RowMatrial model);
  }
}
