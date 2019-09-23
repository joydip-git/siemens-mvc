using PMSAPP.DataAccessLayer.Abstract;
using PMSAPP.Entities;
using PMSAPP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PMSAPP.DataAccessLayer.Implementation
{
    public class ProductDataAccessComponent : IDataAccess<Product>
    {
        public int DeleteRecord(int id)
        {
            bool status = false;

            try
            {
                var repo = DataRepository.GetProducts();
                var foundlist = repo.Where(p => p.ProductId == id);
                if (foundlist != null && foundlist.Count() > 0)
                {
                    var found = foundlist.First();
                    status = foundlist.ToList<Product>().Remove(found);
                }
                else
                    throw new Exception("product doesn't exist");

                if (status)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            var repo = DataRepository.GetProducts();
            return repo;

        }

        public Product GetData(int id)
        {
            Product found = null;
            try
            {
                var repo = DataRepository.GetProducts();
                var foundlist = repo.Where(p => p.ProductId == id);
                if (foundlist != null && foundlist.Count() > 0)
                {
                    found = foundlist.First();
                }
                else
                    throw new Exception("product doesn't exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return found;
        }

        public int InsertRecord(Product data)
        {
            bool status = false;
            try
            {
                var repo = DataRepository.GetProducts() as HashSet<Product>;
                var found = repo.Where(p => p.ProductId == data.ProductId).First();
                if (found == null)
                {
                    status = repo.Add(data);
                }
                else
                    throw new Exception("product already exists");
                if (status)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateRecord(Product data)
        {
            bool status = false;
            try
            {
                var repo = DataRepository.GetProducts() as HashSet<Product>;
                var found = repo.Where(p => p.ProductId == data.ProductId).First();
                if (found != null)
                {
                    //repo.Remove(found);
                    //repo.Add(data);
                    found.ProductName = data.ProductName;
                    found.Price = data.Price;
                    found.Description = data.Description;
                    found.CategoryInfo = data.CategoryInfo;
                    status = true;
                }
                else
                    throw new Exception("product doesn't exist");

                if (status)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
