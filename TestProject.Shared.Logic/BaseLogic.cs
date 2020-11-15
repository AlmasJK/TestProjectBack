using System.Threading.Tasks;
using TestProject.Shared.Data.Context;
using TestProject.Shared.Data.Repos;

namespace TestProject.Shared.Logic
{
    public class BaseLogic : IBaseLogic
    {
        private readonly DataContext _context = null;
        public BaseLogic(DataContext context)
        {
            _context = context;
        }

        public BaseRepo<T> Of<T>() where T : BaseEntity
        {
            return new BaseRepo<T>(_context);
        }
    }
}
