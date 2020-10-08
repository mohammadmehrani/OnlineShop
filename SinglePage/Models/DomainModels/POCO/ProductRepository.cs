using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SinglePage.Models.DomainModels.DTO;
using System.Web.Mvc;


namespace SinglePage.Models.DomainModels.POCO
{
    public class ProductRepository
    {
        #region [- ctor -]
        public ProductRepository()
        {

        }
        #endregion

        #region [- Tasks -]

        #region [- Select() -]
        public List<DTO.EF.product> Select()
        {
            using (var context = new DTO.EF.OnlineStoreEntities1())
            {
                try
                {

                    var q = context.product.Include(p => p.Category).Select(c => c).ToList();
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

        #region [- Insert(Product ref_Product) -]
        public void Insert(DTO.EF.product ref_Product)
        {
            using (var context = new DTO.EF.OnlineStoreEntities1())
            {
                try
                {
                    context.product.Add(ref_Product);
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

        #region [- SelectCategoryFields() -]
        public dynamic SelectCategoryFields()
        {

            using (var context = new DTO.EF.OnlineStoreEntities1())
            {
                try
                {
                    //var categories= new SelectList(context.Category, "Id", "Title");
                    var c = context.Category.Select(p => new { p.CategoryId, p.Title }).ToList();
                    return c.ToList();
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
        public Models.DomainModels.DTO.EF.product FindProduct(int? id)
        {
            using (var context = new DTO.EF.OnlineStoreEntities1())
            {
                try
                {
                    var q = context.product.Find(id);
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
        public void Update(Models.DomainModels.DTO.EF.product ref_product)
        {
            using (var context = new DTO.EF.OnlineStoreEntities1())
            {
                try
                {
                    context.Entry(ref_product).State = EntityState.Modified;
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
                    var q = context.product.Find(id);
                    context.product.Remove(q);
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