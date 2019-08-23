using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IClinicSectionManager
{
   public interface IRowMeterialManager
    {
       List<RowMatrial> GetAllRowMeterial(out int totalrecords, RowMatrial model);

       RowMatrial GetRowMeterialById(int id);

       int Save(RowMatrial mt);

       int Edit(RowMatrial mt);

       int Delete(int id);
    }
}
