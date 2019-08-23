using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IEmployeeManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IEmployeeRepository;
using DENTALMIS.DAL.Repository.EmployeeRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.EmployeeManager
{
  public  class EmployeeDesignationManager:IEmployeeDesignationManager
  {

      private IEmployeeDesignationRepository _employeeDesignationRepository = null;


      public EmployeeDesignationManager(DENTALERPDbContext context)
      {
          _employeeDesignationRepository=new EmployeeDesignationRepository(context);
      }

      public List<Employeedesignation> GetAllDesignationByPaging(out int totalrecord, Employeedesignation model)
      {
          List<Employeedesignation> employeedesignations;


          try
          {
              employeedesignations = _employeeDesignationRepository.GetAllDesignationByPaging(out totalrecord, model);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }

          return employeedesignations;
      }

      public Employeedesignation GetDesignationById(int id)
      {
          Employeedesignation empd;
          try
          {
              empd =
                  _employeeDesignationRepository.FindOne(x => x.EmployeeDesignationId == id && x.IsActive == true);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return empd;
      }

      public int Save(Employeedesignation empds)
      {
          int saveIndex = 0;

          try
          {
              empds.IsActive = true;

              saveIndex = _employeeDesignationRepository.Save(empds);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(Employeedesignation empds)
      {
          int editIndex = 0;

          try
          {
              Employeedesignation _emplds = GetDesignationById(empds.EmployeeDesignationId);

              _emplds.EmployeeDesignationId = empds.EmployeeDesignationId;
              _emplds.DesinationName = empds.DesinationName;
             

              editIndex = _employeeDesignationRepository.Save(_emplds);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int Delete(int id)
      {
          int deleteIndex = 0;

          try
          {
               Employeedesignation emds = GetDesignationById(id);

              emds.IsActive = false;

              deleteIndex = _employeeDesignationRepository.Edit(emds);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return deleteIndex; 
      }

      public List<Employeedesignation> GetAllDesignation()
      {

          List<Employeedesignation> employeedesignations;


          try
          {
              employeedesignations = _employeeDesignationRepository.Filter(x => x.IsActive == true).ToList();
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return employeedesignations;
          
      }
  }
}
