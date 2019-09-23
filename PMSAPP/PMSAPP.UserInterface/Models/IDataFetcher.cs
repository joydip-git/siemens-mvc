using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}