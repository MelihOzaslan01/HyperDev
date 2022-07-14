using HyperDev.Core.IUnitOfWork;
using HyperDev.Core.Models;
using HyperDev.Core.Repositories;
using HyperDev.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperDev.Service.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        public CompanyService(IGenericRepository<Company> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
