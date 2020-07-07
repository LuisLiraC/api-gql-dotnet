using APIGraphQL.Models;
using System.Threading.Tasks;

namespace APIGraphQL.Services
{
    public interface IChampionService
    {
        Task<Champion> GetAsync(string name);
    }
}
