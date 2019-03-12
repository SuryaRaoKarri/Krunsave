using System.Threading.Tasks;
using Krunsave.Model;

namespace Krunsave.Data.IRepository
{
    public interface IEditRepository
    {
        Task<bool> Editstore(Store store);
    }
}