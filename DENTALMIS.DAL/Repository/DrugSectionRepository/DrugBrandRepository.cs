using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DENTALMIS.DAL.IRepository.IDrugSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DrugSectionRepository
{
   public class DrugBrandRepository:Repository<DrugBrand>,IDrugBrandRepository
   {
       public DrugBrandRepository(DENTALERPDbContext context) : base(context)
       {
       }
        public List<DrugBrand> GetAllDrugBrand(out int totalrecords, DrugBrand model)
       {
           var index = model.PageIndex;
           var pageSize = AppConfig.PageSize;
           IQueryable<DrugBrand> drugBrands =
               Context.DrugBrands.Include(x => x.DrugGeneric)
               .Where(x => x.IsActive && (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null)&&(x.GenericId == model.GenericId || model.GenericId == 0));
           //drugBrands = drugBrands.Where(x => x.GenericId == model.GenericId || model.GenericId == 0);
           //.Where(x => x.IsActive &&( x.BrandId == model.BrandId || model.BrandId == 0));

           //&&(x.GenericId == model.GenericId || model.GenericId == 0));
           //.Where(x => x.IsActive && (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null) ||(x.GenericId == model.GenericId || model.GenericId == 0));
           //Context.DrugBrands.Include(x => x.DrugGeneric).Where(x =>
           //    x.IsActive &&
           //    (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null));

            totalrecords = drugBrands.Count();

           switch (model.Sort)
           {
               case "Name":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           drugBrands =
                               drugBrands.OrderByDescending(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           drugBrands = drugBrands.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "Preparation":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           drugBrands =
                               drugBrands.OrderByDescending(p => p.Preparation).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           drugBrands = drugBrands.OrderBy(p => p.Preparation).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;
               case "GenericId":
                   switch (model.SortDir)
                   {
                       case "DESC":
                           drugBrands =
                               drugBrands.OrderByDescending(p => p.DrugGeneric.Name).Skip(index * pageSize).Take(pageSize);
                           break;

                       default:
                           drugBrands = drugBrands.OrderBy(p => p.DrugGeneric.Name).Skip(index * pageSize).Take(pageSize);
                           break;
                   }
                   break;

               default:
                   drugBrands = drugBrands.OrderBy(p => p.Name).Skip(index * pageSize).Take(pageSize);
                   break;
           }

           return drugBrands.ToList();
       }

       //public List<DrugBrand> GetAllDrugBrand(int startPage, int _pageSize, out int totalrecords, DrugBrand model)
       //{
       //    IQueryable<DrugBrand> drugBrands =
       //        //Context.DrugBrands.Include(x => x.DrugGeneric).Where(x => x.GenericId == model.GenericId || model.GenericId == 0);
       //        //.Where(x => x.IsActive && (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null));
       //    //drugBrands = drugBrands.Where(x => x.GenericId == model.GenericId || model.GenericId == 0);
       //    //.Where(x => x.IsActive &&( x.BrandId == model.BrandId || model.BrandId == 0));

       //    //&&(x.GenericId == model.GenericId || model.GenericId == 0));
       //       Context.DrugBrands.Include(x => x.DrugGeneric) .Where(x => x.IsActive && (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null) &&(x.GenericId == model.GenericId || model.GenericId == 0));
       //    //Context.DrugBrands.Include(x => x.DrugGeneric).Where(x =>
       //    //    x.IsActive &&
       //    //    (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null));

       //    totalrecords = drugBrands.Count();

       //    switch (model.Sort)
       //    {
       //        case "Name":
       //            switch (model.SortDir)
       //            {
       //                case "DESC":
       //                    drugBrands =
       //                        drugBrands.OrderByDescending(p => p.Name).Skip(startPage * _pageSize).Take(_pageSize);
       //                    break;

       //                default:
       //                    drugBrands = drugBrands.OrderBy(p => p.Name).Skip(startPage * _pageSize).Take(_pageSize);
       //                    break;
       //            }
       //            break;
       //        case "Preparation":
       //            switch (model.SortDir)
       //            {
       //                case "DESC":
       //                    drugBrands =
       //                            drugBrands.OrderByDescending(p => p.Preparation).Skip(startPage * _pageSize).Take(_pageSize);
       //                    break;

       //                default:
       //                    drugBrands = drugBrands.OrderBy(p => p.Preparation).Skip(startPage * _pageSize).Take(_pageSize);
       //                    break;
       //            }
       //            break;
       //        case "GenericId":
       //            switch (model.SortDir)
       //            {
       //                case "DESC":
       //                    drugBrands =
       //                            drugBrands.OrderByDescending(p => p.DrugGeneric.Name).Skip(startPage * _pageSize).Take(_pageSize);
       //                    break;

       //                default:
       //                    drugBrands = drugBrands.OrderBy(p => p.DrugGeneric.Name).Skip(startPage * _pageSize).Take(_pageSize);
       //                    break;
       //            }
       //            break;

       //        default:
       //            drugBrands = drugBrands.OrderBy(p => p.Name).Skip(startPage * _pageSize).Take(_pageSize);
       //            break;
       //    }

       //    return drugBrands.ToList();
       //}

       public List<DrugBrand> GetAllDrugBrandByGeneric(int genericId)
       {
           List<DrugBrand> drugBrands;
           try
           {
               drugBrands = Context.DrugBrands.Where(x => x.GenericId == genericId && x.IsActive == true).ToList();
           }
           catch (Exception exception)
           {

               throw new Exception(exception.Message);
           }
           return drugBrands;
       }
   }
}
