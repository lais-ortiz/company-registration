using CompanyRegistration.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CompanyRegistration.Service
{
    public class CompaniesService : ICompaniesService
    {
        private readonly IMongoCollection<Company> _companiesCollection;
        private readonly IConfiguration _configuration;

        public CompaniesService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            var connectionString = _configuration["CompaniesDatabase:ConnectionString"];
            var mongoClient = new MongoClient(connectionString);

            var databaseName = _configuration["CompaniesDatabase:DatabaseName"];
            var mongoDatabase = mongoClient.GetDatabase(databaseName);

            var collectionName = _configuration["CompaniesDatabase:CollectionName"];
            _companiesCollection = mongoDatabase.GetCollection<Company>(collectionName);
        }

        public async Task<IList<Company>> GetAsync() =>
            await _companiesCollection.Find(_ => true).ToListAsync();

        public async Task<Company?> GetAsync(int id) =>
            await _companiesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task AddAsync(Company newCompany) =>
            await _companiesCollection.InsertOneAsync(newCompany);

        public async Task UpdateAsync(int id, Company updatedCompany) =>
            await _companiesCollection.ReplaceOneAsync(x => x.Id == id, updatedCompany);

        public async Task RemoveAsync(int id) =>
            await _companiesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
