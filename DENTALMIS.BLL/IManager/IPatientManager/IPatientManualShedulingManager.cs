using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IPatientManager
{
   public interface IPatientManualShedulingManager
    {
        List<string> GetPatientValue(string patientCode, DateTime date);

        string SavePatientShedule(PatientShedule patientShedule);
    }
}
