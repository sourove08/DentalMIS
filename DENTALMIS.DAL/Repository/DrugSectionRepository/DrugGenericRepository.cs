using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DENTALMIS.DAL.IRepository.IDrugSectionRepository;
using DENTALMIS.Model;
using DENTALMIS.Utility;

namespace DENTALMIS.DAL.Repository.DrugSectionRepository
{
    public class DrugGenericRepository :Repository<DrugGeneric>, IDrugGenericRepository
    {
        public DrugGenericRepository(DENTALERPDbContext context) : base(context)
        {
        }

        //public List<DrugGeneric> GetAllGenericDrug(int startPage, int _pageSize, out int totalRecords, DrugGeneric model)
        //{
        //    var drugGenerics =
        //        Context.DrugGenerics.Where(
        //            x =>
        //                x.IsActive &&
        //                (x.GenericId == model.GenericId || model.GenericId == 0));
        //                //(x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null));

        //    totalRecords = drugGenerics.Count();

        //    switch (model.Sort)
        //    {
        //        case "Name":
        //            switch (model.SortDir)
        //            {
        //                case "DESC":
        //                    drugGenerics =
        //                        drugGenerics.OrderByDescending(r => r.Name).Skip(startPage * _pageSize).Take(_pageSize);
        //                    break;
        //                default:
        //                    drugGenerics = drugGenerics.OrderBy(r => r.Name).Skip(startPage * _pageSize).Take(_pageSize);
        //                    break;
        //            }
        //            break;

        //        default:
        //            drugGenerics = drugGenerics.OrderBy(r => r.Name).Skip(startPage * _pageSize).Take(_pageSize);
        //            break;
        //    }
        //    return drugGenerics.ToList();
        //}
        public List<DrugGeneric> GetAllGenericDrug( out int totalRecords, DrugGeneric model)
        {
            int index = model.PageIndex;
            int pageSize = AppConfig.PageSize;
            var drugGenerics =
                Context.DrugGenerics.Where(
                    x =>
                        x.IsActive &&
                        //(x.GenericId == model.GenericId || model.GenericId == 0));
                        (x.Name.Trim().ToLower().Contains(model.Name.Trim().ToLower()) || model.Name == null));

            totalRecords = drugGenerics.Count();

            switch (model.Sort)
            {
                case "Name":
                    switch (model.SortDir)
                    {
                        case "DESC":
                            drugGenerics =
                                drugGenerics.OrderByDescending(r => r.Name).Skip(index*pageSize).Take(pageSize);
                            break;
                        default:
                            drugGenerics = drugGenerics.OrderBy(r => r.Name).Skip(index * pageSize).Take(pageSize);
                            break;
                    }
                    break;

                default:
                    drugGenerics = drugGenerics.OrderBy(r => r.Name).Skip(index * pageSize).Take(pageSize);
                    break;
            }
            return drugGenerics.ToList();
        }
    }
}
