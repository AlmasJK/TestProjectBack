using TestProject.Shared.Data.Context;
using TestProject.Shared.Data.Repos;

namespace TestProject.Shared.Logic
{
    public interface IBaseLogic
    {
        BaseRepo<T> Of<T>() where T : BaseEntity;
    }
}
