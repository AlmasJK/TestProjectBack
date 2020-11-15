using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Shared.Data.Context;

namespace TestProject.Shared.Data.Repos
{
    public class UnitOfWork: IUnitOfWork
    {
        public readonly DataContext _dataContext;

		public UnitOfWork(DataContext dataContext){
            _dataContext = dataContext;

        }

        public async Task Commit() {
			await _dataContext.SaveChangesAsync();
		}

		public void Dispose() {
			_dataContext.Dispose();
		}

        public DataContext GetContext()
        {
            return _dataContext;
        }

        public async Task RejectChanges() {
			foreach (var entry in _dataContext.ChangeTracker.Entries()
					.Where(e => e.State != EntityState.Unchanged)) {
				switch (entry.State) {
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;
					case EntityState.Modified:
					case EntityState.Deleted:
						await entry.ReloadAsync();
						break;
				}
			}
		}
    }
}