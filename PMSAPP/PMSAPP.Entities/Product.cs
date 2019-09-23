using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSAPP.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //foreign key column
        public int CategoryId { get; set; }
        //navigation property
        public Category CategoryInfo { get; set; }
        public Product()
        {

        }
        public Product(int productId, string productName, string description, decimal price, Category category)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            this.Price = price;
            this.CategoryInfo = category;
            if (this.CategoryInfo != null)
                this.CategoryId = this.CategoryInfo.CategoryId;
        }

        public override string ToString()
        {
            return $"{this.ProductId},{this.ProductName},{this.Description},{this.Price}";
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is Product)
                {
                    Product other = obj as Product;

                    if (this == other)
                        return true;

                    if (!this.ProductId.Equals(other.ProductId))
                        return false;

                    if (!this.ProductName.Equals(other.ProductName))
                        return false;

                    if (!this.Description.Equals(other.Description))
                        return false;

                    if (!this.Price.Equals(other.Price))
                        return false;

                    if (!this.CategoryId.Equals(other.CategoryId))
                        return false;

                    if (!this.CategoryInfo.Equals(other.CategoryInfo))
                        return false;

                    return true;
                }
                else
                    throw new ArgumentException($"argument of type {obj.GetType().Name} has been passed to Equals method instead of {this.GetType().Name}");
            }
            else
                throw new NullReferenceException($"null reference has been sent to Equals method");
        }

        public override int GetHashCode()
        {
            const int prime = 23;
            int hash = 0;
            hash = this.ProductId.GetHashCode() * prime;
            hash = this.ProductName != null ? this.ProductName.GetHashCode() * hash : hash * prime;
            hash = this.Description != null ? this.Description.GetHashCode() * hash : hash * prime;
            hash = this.Price.GetHashCode() * hash;
            return hash;
        }
    }
}
