using PMSAPP.BusinessLogicLayer.Abstract;
using PMSAPP.BusinessLogicLayer.Implementation;
using PMSAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMSAPP.UserInterface.Models
{
    public class DataFetcher : IDataFetcher<Product>
    {
        private IBusinessComponent<Product> businessComponent;
        public DataFetcher()
        {
            businessComponent = new ProductBusinessComponent();
        }
        public int AddData(Product data)
        {
            try
            {
               return businessComponent.Add(data);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Product> GetAllRecords()
        {
            try
            {
                return businessComponent.FetchAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetData(int id)
        {
            try
            {
                return businessComponent.Fetch(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int RemoveData(int id)
        {
            try
            {
                return businessComponent.Remove(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateData(Product data)
        {
            try
            {
                return businessComponent.Update(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}