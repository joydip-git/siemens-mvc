using System.Collections.Generic;

namespace PMSAPP.BusinessLogicLayer.Abstract
{
    public interface IBusinessComponent<T> where T : class
    {
        int Add(T data);
        int Remove(int id);
        int Update(T data);
        IEnumerable<T> FetchAll();
        T Fetch(int id);
    }
}
