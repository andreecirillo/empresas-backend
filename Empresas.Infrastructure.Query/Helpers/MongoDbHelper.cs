using MongoDB.Driver;

namespace Empresas.Infrastructure.Query.Helpers
{
    public class MongoDbHelper
    {
        private readonly IMongoDatabase _database;

        public MongoDbHelper(string connectionString)
        {
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;

            if (string.IsNullOrEmpty(databaseName))
            {
                throw new ArgumentException("O nome da base de dados não foi especificado na string de conexão.");
            }

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
