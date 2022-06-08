using Moga_Stefan_Proiect.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Moga_Stefan_Proiect.Services
{
    public class OrderListDatabase
    {
        IRestService restService;

        public OrderListDatabase(IRestService service)
        {
            restService = service;
        }
        public Task<List<NewOrder>> GetOrderListsAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}
