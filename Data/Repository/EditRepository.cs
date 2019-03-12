using System.Threading.Tasks;
using Krunsave.Data.IRepository;
using Krunsave.Model;
using Microsoft.EntityFrameworkCore;

namespace Krunsave.Data.Repository
{
    public class EditRepository : IEditRepository
    {
        private readonly DataContext _context;
        public EditRepository(DataContext context){
            _context = context;
        }

        public async Task<Store> Editstore(Store store)
        {
            var storedetails = await _context.Stores.FirstOrDefaultAsync(s => s.storeID == store.storeID);
            storedetails.storeName = "Snack Bar";
           // _context.Stores.Update(storedetails);
            _context.SaveChanges();
            return storedetails;
        }
    }
}