using PMSAPP.BusinessLogicLayer.Abstract;
using PMSAPP.BusinessLogicLayer.Implementation;
using PMSAPP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace PMSAPP.UserInterface.Models
{
    public class DataFetcher : IDataFetcher<Product>
    {
        private readonly IBusinessComponent<Product> businessComponent;
        public DataFetcher(IBusinessComponent<Product> businessComponent)
        {
            this.businessComponent = businessComponent;
        }
        public int AddData(Product data)
        {
            try
            {
                return businessComponent.Add(data);
            }
            catch (Exception ex)
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

    public class DataFetcherAsync : IDataFetcherAsync<Product>
    {
        private string GetBaseUrl()
        {
            try
            {
                return ConfigurationManager.AppSettings["BASEURL"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<int> AddData(Product data)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllRecords()
        {
            IEnumerable<Product> products = null;
            try
            {
                string baseUrl = GetBaseUrl();
                if (string.IsNullOrEmpty(baseUrl))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress
                            = new Uri(baseUrl);
                        client
                            .DefaultRequestHeaders
                            .Clear();
                        client
                            .DefaultRequestHeaders
                            .Accept
                            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        Task<HttpResponseMessage> response = client.GetAsync("getall");
                        var responseData = await response;
                        if (responseData.IsSuccessStatusCode)
                        {
                            string data = responseData
                                .Content
                                .ReadAsStringAsync()
                                .Result;
                            var respData = JsonConvert.DeserializeObject<ProductServiceResponseMessage<IEnumerable<Product>>>(data);
                            products = respData.Data;

                        }
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Product> GetData(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveData(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateData(Product data)
        {
            throw new NotImplementedException();
        }
    }
}