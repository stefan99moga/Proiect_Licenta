using System.Collections.Generic;
using System.Threading.Tasks;
using Moga_Stefan_Proiect.Models;

namespace Moga_Stefan_Proiect.Services
{
    public interface IRestService
    {
        Task<List<Pizza>> RefreshDataAsync();
    }
}
