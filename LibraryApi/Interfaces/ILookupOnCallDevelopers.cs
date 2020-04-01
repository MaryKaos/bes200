using LibraryApi.Models;
using System.Threading.Tasks;

namespace LibraryApi.Interfaces
{
    public interface ILookupOnCallDevelopers
    {
        Task<OnCallDeveloperResponse> GetOnCallDeveoper();
    }
}