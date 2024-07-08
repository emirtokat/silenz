using Application.Interfaces.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : BaseRepository<OperationClaim>, IOperationClaimRepository
    {
        public OperationClaimRepository(AppDbContext context) : base(context)
        {
        }
    }
}
