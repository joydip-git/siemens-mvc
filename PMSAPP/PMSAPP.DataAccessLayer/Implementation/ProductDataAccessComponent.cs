using PMSAPP.DataAccessLayer.Abstract;
using PMSAPP.Entities;
using PMSAPP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace PMSAPP.DataAccessLayer.Implementation
{
    public class ProductDataAccessComponent : IDataAccess<Product>
    {
        public int DeleteRecord(int id)
        {
            //bool status = false;
            int status = 0;
            try
            {
                //var repo = DataRepository.GetProducts();
                using (var db =
                      new siemens_dbEntities())
                {
                    DbSet<product> repo = db.products;
                    var foundlist = repo.Where(p => p.productid == id);
                    if (foundlist != null && foundlist.Count() > 0)
                    {
                        product found = foundlist.First();
                        repo.Remove(found);
                        status = db.SaveChanges();
                    }
                    else
                        throw new Exception("product doesn't exist");
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            //var repo = DataRepository.GetProducts();
            //return repo;
            IEnumerable<Product> products = null;
            try
            {
                using (var db = new siemens_dbEntities())
                {
                    products = db.products.Select(
                        poco => MapPocoProductToDTOProduct(poco));
                }
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetData(int id)
        {
            Product productData = null;
            try
            {
                //var repo = DataRepository.GetProducts();
                using (var db = new siemens_dbEntities())
                {
                    var repo = db.products;
                    var foundlist = repo.Where(p => p.productid == id);
                    if (foundlist != null && foundlist.Count() > 0)
                    {
                        var found = foundlist.First();
                        productData = MapPocoProductToDTOProduct(found);
                    }
                    else
                        throw new Exception("product doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productData;
        }

        public int InsertRecord(Product data)
        {
            //bool status = false;
            int status = 0;
            try
            {
                //var repo = DataRepository.GetProducts() as HashSet<Product>;
                using (var db = new siemens_dbEntities())
                {
                    var repo = db.products;
                    var foundList = repo.Where(p => p.productid == data.ProductId);
                    if (foundList != null && foundList.Count() > 0)
                    {
                        throw new Exception("product already exists");
                    }
                    else
                    {
                        repo.Add(MapDTOProductToPocoProduct(data));
                        status = db.SaveChanges();
                    };
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateRecord(Product data)
        {
            int status = 0;
            try
            {
                //var repo = DataRepository.GetProducts() as HashSet<Product>;

                using (var db = new siemens_dbEntities())
                {
                    var repo = db.products;
                    var foundList = repo.Where(p => p.productid == data.ProductId);
                    if (foundList != null && foundList.Count() > 0)
                    {
                        var found = foundList.First();
                        found.productname = data.ProductName;
                        found.price = data.Price;
                        found.description = data.Description;
                        found.categoryid = data.CategoryId;
                        status = db.SaveChanges();
                        //var foundEntry = db.Entry<product>(found);
                        //foundEntry.State = EntityState.Modified;
                    }
                    else
                        throw new Exception("product doesn't exist");
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Helper Methods
        private static Product MapPocoProductToDTOProduct(product poco)
        {
            return new Product
            {
                ProductId = poco.productid,
                ProductName = poco.productname,
                Price = poco.price.Value,
                Description = poco.description,
                CategoryId = poco.categoryid.Value
            };
        }
        private static product MapDTOProductToPocoProduct(Product data)
        {
            return new product
            {
                productid = data.ProductId,
                productname = data.ProductName,
                description = data.Description,
                price = data.Price,
                categoryid = data.CategoryId
            };
        }
        #endregion
    }
}
