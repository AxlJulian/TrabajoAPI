using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        public readonly RepositoryContext _repositoryContext;
        public readonly Lazy<ICompanyRepository> _companyRepository;
        public readonly Lazy<IEmployeeRepository> _employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _companyRepository = new Lazy<ICompanyRepository>(() => new
            CompanyRepository(repositoryContext));

            _employeeRepository = new Lazy<IEmployeeRepository>(() => new
            EmployeeRepository(repositoryContext));
        }

        public ICompanyRepository Company => _companyRepository.Value;


        public IEmployeeRepository Employee => _employeeRepository.Value;


        public void Save()
        => _repositoryContext.SaveChanges();

    }

}
