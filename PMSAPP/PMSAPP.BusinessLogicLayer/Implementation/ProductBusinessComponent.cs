using PMSAPP.BusinessLogicLayer.Abstract;
using PMSAPP.DataAccessLayer.Abstract;
using PMSAPP.DataAccessLayer.Implementation;
using PMSAPP.Entities;
using System;
using System.Collections.Generic;

namespace PMSAPP.BusinessLogicLayer.Implementation
{
    public class ProductBusinessComponent : IBusinessComponent<Product>
    {
        private readonly IDataAccess<Product> dataAccessObject;

        public ProductBusinessComponent(IDataAccess<Product> dataAccessObject)
        {
            this.dataAccessObject = dataAccessObject;
        }
        public int Add(Product data)
        {
            try
            {
                if (data != null)
                    return dataAccessObject.InsertRecord(data);
                else
                    throw new ArgumentException("no data was passed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product Fetch(int id)
        {
            try
            {
                return dataAccessObject.GetData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> FetchAll()
        {
            try
            {
                return dataAccessObject.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Remove(int id)
        {
            try
            {
                return dataAccessObject.DeleteRecord(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Product data)
        {
            try
            {
                if (data != null)
                    return dataAccessObject.UpdateRecord(data);
                else
                    throw new ArgumentException("no data was passed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
