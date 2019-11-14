using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSyntCli.Models;

namespace TestSyntCli
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(Uri requestUrl);

        Task<MessageModel> PostAsync<T>(Uri requestUrl, T content);
    }
}
