using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDoctorSectionManager
{
  public  interface IDoctorManager
    {
      List<Doctor> GetAllDoctorByPaging(out int totalrecords, Doctor model);

      Doctor GetDoctorById(int id);

      int Save(Doctor _doctor);

     int Edit(Doctor _doctor);

      int Delete(int id);

     
    }
}
