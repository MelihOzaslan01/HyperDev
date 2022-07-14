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
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        public DepartmentService(IGenericRepository<Department> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
