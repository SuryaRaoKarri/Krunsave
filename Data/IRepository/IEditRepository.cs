using System.Threading.Tasks;
using Krunsave.Model;

namespace Krunsave.Data.IRepository
{
    public interface IEditRepository
    {
        Task<Store> Editstore(Store store);
    }
}