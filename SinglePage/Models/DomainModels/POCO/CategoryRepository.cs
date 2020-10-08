using SinglePage.Models.DomainModels.DTO.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SinglePage.Models.DomainModels.POCO
{
    public class CategoryRepository
    {
        #region [- ctor -]
        public CategoryRepository()
        {

        }
        #endregion

        #region [- Tasks -]

        #region [- Select() -]
        public List<Models.DomainModels.DTO.EF.Category> Select()
        {
            using (var context = new Models.DomainModels.DTO.EF.OnlineStoreEntities1())
            {
                try
                {
                    var q = context.Category.ToList();
                    return q;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Insert(Category ref_category) -]
        public void Insert(DTO.EF.Category ref_category)
        {
            using (var context = new DTO.EF.OnlineStoreEntities1())
            {
                try
                {
                    context.Category.Add(ref_category);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- FindId(int? id) -]
        public DTO.EF.Category FindCategory(int? id)
        {
            using (var context = new DTO.EF.OnlineStoreEntities1())
            {
                try
                {
                    var q = context.Category.Find(id);
                    return q;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Update() -]
        public void Update(Category ref_category)
        {
            using (var context = new OnlineStoreEntities1())
            {
                try
                {
                    //var q = context.Category.Find(ref_category.CategoryId);
                    context.Entry(ref_category).State = EntityState.Modified;
                    
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Delete(int id) -]
        public void Delete(int id)
        {
            using (var context = new DTO.EF.OnlineStoreEntities1())
            {
                try
                {
                    var q = context.Category.Find(id);
                    context.Category.Remove(q);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
            #endregion

            #endregion

        
    }
}