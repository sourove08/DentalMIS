using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IPatientManager
{
   public interface IPatientSheduleManager
    {
       List<PatientShedule> GetAllPaging(out int totalrecords, PatientShedule model);
    }
}
