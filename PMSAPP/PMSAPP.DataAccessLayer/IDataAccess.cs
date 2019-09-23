using System.Collections.Generic;

namespace PMSAPP.DataAccessLayer
{
    public interface IDataAccess<T> where T : class
    {
        int InsertRecord(T data);
        int DeleteRecord(int id);
        int UpdateRecord(T data);
        IEnumerable<T> GetAll();
        T GetData(int id);
    }
}
