using Interview.DependencyInjection.InterfacesDI;
using System.Security.Cryptography;

namespace Interview.DependencyInjection.Services
{
    public class SingletonService : ISingletonService
    {
        private readonly Guid _id;
        public SingletonService()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetOperationId() => _id;
       
    }
}
