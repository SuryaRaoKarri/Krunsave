using System.Threading.Tasks;

namespace Krunsave.Data
{
    public class AddStoreRepository : IAddStoreRepository
    {
        private readonly DataContext _context;
        private readonly IAddStoreRepository _addrepo;
        public AddStoreRepository(DataContext context, IAddStoreRepository addrepo){

            _context = context;
            _addrepo = addrepo;


        }
        
        // public bool Addstore(StoreinfoRepository store)
        // {
        //     return true;
        // }
    }
}