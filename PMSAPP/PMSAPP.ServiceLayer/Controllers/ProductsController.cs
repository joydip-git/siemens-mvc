using PMSAPP.BusinessLogicLayer.Abstract;
using PMSAPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMSAPP.ServiceLayer.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IBusinessComponent<Product> businessComponent;

        public ProductsController(IBusinessComponent<Product> businessComponent)
        {
            this.businessComponent = businessComponent;
        }

        public IHttpActionResult GetProducts()
        {
            try
            {
                var allProducts = businessComponent.FetchAll().ToList<Product>();
                return CreateResponseMessage<
                    IEnumerable<Product>>(
                    allProducts, "data fetched sucessfully");
            }
            catch (Exception ex)
            {
                return CreateResponseMessage<Exception>(
                    ex, null);
            }
        }

        public IHttpActionResult GetProduct(
            [FromUri]int? id)
        {
            try
            {
                var product = businessComponent
                    .Fetch(id.Value);
                return CreateResponseMessage<Product>(
                    product, "data fetched successfully");
            }
            catch (Exception ex)
            {
                return this.CreateResponseMessage<Exception>(ex, null);
            }
        }

        public IHttpActionResult AddProduct(
            [FromBody]Product product)
        {
            try
            {
                var addStatus = businessComponent.Add(product);
                return CreateResponseMessage<int>(addStatus, $"{addStatus} product added successfully");
            }
            catch (Exception ex)
            {
                return this.CreateResponseMessage<Exception>(ex, null);
            }
        }

        public IHttpActionResult UpdateProduct([FromBody]Product product)
        {
            try
            {
                var updateStatus = businessComponent.Update(product);
                return CreateResponseMessage<int>(updateStatus, $"{updateStatus} product updated successfully");
            }
            catch (Exception ex)
            {
                return this.CreateResponseMessage<Exception>(ex, null);
            }
        }

        public IHttpActionResult RemoveProduct(int? id)
        {
            try
            {
                var deleteStatus = businessComponent.Remove(id.Value);
                return CreateResponseMessage<int>(deleteStatus, $"{deleteStatus} product deleted successfully");
            }
            catch (Exception ex)
            {
                return this.CreateResponseMessage<Exception>(ex, null);
            }
        }

        #region Helper Methods
        private IHttpActionResult CreateResponseMessage<T>(T data, string message)
        {
            if (!(data is Exception))
            {
                ProductServiceResponseMessage<T> successResponse = new ProductServiceResponseMessage<T>
                {
                    Data = data,
                    Message = message
                };
                return this.Content<
                     ProductServiceResponseMessage<T>>(
                     HttpStatusCode.OK,
                     successResponse
                     );
            }
            else
            {
                Exception ex = data as Exception;
                return this.Content<string>(
                    HttpStatusCode.BadRequest,
                    ex.ToString());
            }
        }
        #endregion
    }
}
