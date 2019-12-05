using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataCentral
{
    public interface IRequester
    {
        Task<string> GetRawAsync(string url);

        Task<T> GetAsync<T>(string url);

        Task<string> PostRawAsync(string url, string body);

        Task<T> PostAsync<T>(string url, string body);
    }
}