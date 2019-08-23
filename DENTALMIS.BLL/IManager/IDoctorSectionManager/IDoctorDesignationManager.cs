using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.IManager.IDoctorSectionManager
{
   public interface IDoctorDesignationManager
    {
       List<DoctorsDesignation> GetAllDesignationByPaging(out int totalrecord, DoctorsDesignation model);

       DoctorsDesignation GetDesignationById(int id);

       int Save(DoctorsDesignation doctorsDesignation);

       int Edit(DoctorsDesignation doctorsDesignation);

       int Delete(int dId);

       List<DoctorsDesignation> GetAllDesignation();
    }
}
