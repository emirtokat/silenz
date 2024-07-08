using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IRefreshTokenRepository :IEntityReadRepository<RefreshToken>, IEntityRepository<RefreshToken>

    {
    }
}
