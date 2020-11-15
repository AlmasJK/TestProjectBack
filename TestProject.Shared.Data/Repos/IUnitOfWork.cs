using System.Threading.Tasks;
using TestProject.Shared.Data.Context;

namespace TestProject.Shared.Data.Repos
{
    public interface IUnitOfWork
    {
        DataContext GetContext();
        Task Commit();
        Task RejectChanges();
        void Dispose();
    }
}