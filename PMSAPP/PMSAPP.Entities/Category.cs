using System;

namespace PMSAPP.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category()
        {

        }
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public override string ToString()
        {
            return $"{this.CategoryId},{this.CategoryName}";
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is Category)
                {
                    Category other = obj as Category;

                    if (this == other)
                        return true;

                    if (!this.CategoryId.Equals(other.CategoryId))
                        return false;

                    if (!this.CategoryName.Equals(other.CategoryName))
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
            hash = this.CategoryId.GetHashCode() * prime;
            hash = this.CategoryName != null ? this.CategoryName.GetHashCode() * hash : hash * prime;
            return hash;
        }
    }
}
