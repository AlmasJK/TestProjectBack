 using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using TestProject.Shared.Data.Context;
using TestProject.Shared.Data.Repos;

namespace TestProject.Shared.Logic
{
    public abstract class ABaseLogic
    {
        private readonly DataContext _context = null;

        protected ABaseLogic(DataContext context)
        {
            _context = context;
        }

        public BaseRepoDbSet Database()
        {
            var _ = new BaseRepoDbSet(_context);
            return _;
        }

        protected virtual void Dispose()
        {
            _context.Dispose();
        }
    }

    public class BaseRepoDbSet : DynamicObject
    {
        private readonly DataContext _context;
        protected IUnitOfWork Database { get; set; }
        protected IEnumerable<BaseEntity> _subTypes;

        public BaseRepoDbSet(DataContext context)
        {
            _context = context;
            _subTypes = ReflectiveEnumerator.GetEnumerableOfType<BaseEntity>();
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _subTypes.Select(a=>a.GetType().Name);
        }
    }

    public static class ReflectiveEnumerator
    {
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            List<T> objects = new List<T>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(T)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
            {
                objects.Add((T)Activator.CreateInstance(type, constructorArgs));
            }
            return objects;
        }
    }
}
