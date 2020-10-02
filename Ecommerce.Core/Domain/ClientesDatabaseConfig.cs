

namespace Ecommerce.Core.Domain
{
    public class ClientesDatabaseConfig: IClientesDatabaseConfig
    {
        public string ClientesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IClientesDatabaseConfig
    {
        string ClientesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
