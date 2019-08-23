using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.Model;

namespace DENTALMIS.DAL.IRepository.IDoctorSectionRepositoy
{
  public  interface IDoctorDesignationRepossitory:IRepository<DoctorsDesignation>
  {
      List<DoctorsDesignation> GetAllDesignationByPaging(out int totalrecord, DoctorsDesignation model);
  }
}
