using CompanyRegistration.Domain.Entities;

namespace CompanyRegistration.Service
{
    public interface ICompaniesService
    {
        Task<IList<Company>> GetAsync();

        Task<Company?> GetAsync(int id);

        Task AddAsync(Company newCompany);

        Task UpdateAsync(int id, Company updatedCompany);

        Task RemoveAsync(int id);
    }
}
