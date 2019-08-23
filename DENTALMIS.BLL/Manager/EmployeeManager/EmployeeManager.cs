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
  public  class EmployeeManager:IEmployeeManager
  {

      private IEmployeeRepository _employeeRepository = null;


      public EmployeeManager(DENTALERPDbContext context)
      {
          _employeeRepository=new EmployeeRepository(context);
      }

      public List<ClinicEmployee> GetAllEmployeeByPaging(out int totalrecords, ClinicEmployee model)
      {
          List<ClinicEmployee> clinicEmployees;
          try
          {
              clinicEmployees = _employeeRepository.GetAllEmployeeByPaging(out totalrecords, model);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return clinicEmployees;
      }

      public ClinicEmployee GetEmployeeById(int id)
      {
          ClinicEmployee emp;


          try
          {
              emp = _employeeRepository.FindOne(x => x.ClinicEmployeeId == id && x.IsActive == true);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }
          return emp;
      }

      public int Save(ClinicEmployee _employee)
      {
          int saveIndex = 0;

          try
          {
              _employee.IsActive = true;
              saveIndex = _employeeRepository.Save(_employee);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return saveIndex;
      }

      public int Edit(ClinicEmployee _employee)
      {

          int editIndex = 0;

          try
          {

              ClinicEmployee emp = GetEmployeeById(_employee.ClinicEmployeeId);

              emp.ClinicEmployeeId = _employee.ClinicEmployeeId;
              emp.GenderId = _employee.GenderId;
              emp.EmployeeDesignationId = _employee.EmployeeDesignationId;
              emp.Name = _employee.Name;
              emp.Salary = _employee.Salary;
              emp.Address = _employee.Address;
              emp.Contact = _employee.Contact;
              emp.Email = _employee.Email;

              editIndex = _employeeRepository.Edit(emp);
          }
          catch (Exception exception)
          {

              throw new Exception(exception.Message);
          }
          return editIndex;
      }

      public int Delete(int id)
      {
          int deletIndex = 0;


          try
          {
              ClinicEmployee employee = GetEmployeeById(id);
              employee.IsActive = false;
              deletIndex = _employeeRepository.Edit(employee);
          }
          catch (Exception exception)
          {
              
              throw new Exception(exception.Message);
          }

          return deletIndex;
      }
  }
}
