using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.BLL.IManager.IDrugSectionManager;
using DENTALMIS.DAL;
using DENTALMIS.DAL.IRepository.IDrugSectionRepository;
using DENTALMIS.DAL.Repository.DrugSectionRepository;
using DENTALMIS.Model;

namespace DENTALMIS.BLL.Manager.DrugSectionManager
{
   public class DrugBrandManager:IDrugBrandManager
   {
       private IDrugBrandRepository _drugBrandRepository = null;

       public DrugBrandManager(DENTALERPDbContext context)
       {
           _drugBrandRepository=new DrugBrandRepository(context);
       }

       //public List<DrugBrand> GetAllDrugBrand(int startPage, int _pageSize, out int totalrecords, DrugBrand model)
       //{
       //    List<DrugBrand> _drugBrands;

       //    try
       //    {
       //        _drugBrands = _drugBrandRepository.GetAllDrugBrand(startPage, _pageSize, out totalrecords, model);
       //    }
       //    catch (Exception exception)
       //    {

       //        throw new Exception(exception.Message);
       //    }
       //    return _drugBrands;
       //}
       public List<DrugBrand> GetAllDrugBrand(out int totalrecords, DrugBrand model)
       {
           List<DrugBrand> _drugBrands;

           try
           {
               _drugBrands = _drugBrandRepository.GetAllDrugBrand(out totalrecords, model);
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return _drugBrands;
       }

       public DrugBrand GetBrandDrugById(int brandId)
       {
           var _drugBrand = new DrugBrand();

           try
           {
               _drugBrand = _drugBrandRepository.FindOne(x => x.BrandId == brandId);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return _drugBrand;
       }

       public int SaveDrugBrand(DrugBrand _drugBrand)
       {
           int saveIndex = 0;
           try
           {
               _drugBrand.IsActive = true;
               saveIndex = _drugBrandRepository.Save(_drugBrand);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return saveIndex;
       }

       public int EditDrugBrand(DrugBrand _drugBrand)
       {
           int editIndex = 0;
           try
           {
               DrugBrand drugBrand = GetBrandDrugById(_drugBrand.BrandId);
               drugBrand.Name = _drugBrand.Name;
               drugBrand.Preparation = _drugBrand.Preparation;
               drugBrand.GenericId = _drugBrand.GenericId;
               editIndex = _drugBrandRepository.Edit(drugBrand);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return editIndex;
       }

       public int DeleteDrugBrand(int brandId)
       {
           int deleteIndex = 0;

           try
           {
               var drugBrand = GetBrandDrugById(brandId);
               drugBrand.IsActive = false;
               deleteIndex = _drugBrandRepository.Edit(drugBrand);
           }
           catch (Exception exception)
           {
               
               throw new Exception(exception.Message);
           }
           return deleteIndex;
       }

       public List<DrugBrand> GetdrugBySearchKey(string SearchKey)
       {
               var drugBrands = new List<DrugBrand>();
            try
            {
                drugBrands = !String.IsNullOrEmpty(SearchKey)
                    ? _drugBrandRepository.Filter(x => x.Name.Replace(" ", "").ToLower().Contains(SearchKey.Replace(" ", "").ToLower())).ToList()
                    : _drugBrandRepository.Filter(x => x.IsActive == true).ToList();

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return drugBrands;
        }

       public List<DrugBrand> Getdrugs()
       {
           var drugBrands = new List<DrugBrand>();
           try
           {
               drugBrands = _drugBrandRepository.All().Include(x=>x.DrugGeneric).Where(x => x.IsActive == true).ToList();

           }
           catch (Exception exception)
           {
               throw new Exception(exception.Message);
           }
           return drugBrands;
       }
   }

       //public List<DrugBrand> GetAllDrugBrandByGeneric(int genericId)
       //{
       //    List<DrugBrand> drugBrands;
       //    try
       //    {
       //        drugBrands = _drugBrandRepository.GetAllDrugBrandByGeneric(genericId);
       //    }
       //    catch (Exception exception)
       //    {
               
       //        throw new Exception(exception.Message);
       //    }
       //    return drugBrands;
       //}
   }

