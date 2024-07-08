using Application.Interfaces.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : BaseRepository<UserOperationClaim>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(AppDbContext context) : base(context)
        {
        }
    }
}
