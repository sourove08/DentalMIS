using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.ITodayStatusManager
{
   public interface ITodayStatusManager
    {
       List<TodaysPatientstatu> GetAllStatusByPaging(out int totalrecord, TodaysPatientstatu model);

       TodaysPatientstatu GetStatusById(int id);

       int Save(TodaysPatientstatu todaysPatientstatu);

       int Edit(TodaysPatientstatu todaysPatientstatu);

       int Delete(int id);
    }
}
