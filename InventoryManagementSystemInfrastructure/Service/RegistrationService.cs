using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.DataContext;
using InventoryManagementSystemInfrastructure.IService;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemInfrastructure.Service
{
    internal class RegistrationService : BaseService<Login>, IRegistrationService
    {
        private readonly ApplicationDbContext dbContext;
        public RegistrationService(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
