using LibraryApi.Domain;
using System.Threading.Tasks;

namespace LibraryApi.Interfaces
{
    public interface IWriteToTheReservationQueue
    {
        Task Write(Reservation reservation);
    }
}