using Interview.DependencyInjection.InterfacesDI;

namespace Interview.DependencyInjection.Services
{
    public class ScopedService : IScopedService
    {
        private readonly Guid _id;
/* it will creat new id */
        public ScopedService()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetOperationId() => _id;
    }
}
