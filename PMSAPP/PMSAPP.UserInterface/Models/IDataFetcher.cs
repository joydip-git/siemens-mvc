using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMSAPP.UserInterface.Models
{
    public interface IDataFetcher<T> where T : class
    {
        T GetData(int id);
        IEnumerable<T> GetAllRecords();
        int AddData(T data);
        int RemoveData(int id);
        int updateData(T data);
    }
    public interface IDataFetcherAsync<T> where T : class
    {
        Task<T> GetData(int id);
        Task<IEnumerable<T>> GetAllRecords();
        Task<int> AddData(T data);
        Task<int> RemoveData(int id);
        Task<int> UpdateData(T data);
    }
}