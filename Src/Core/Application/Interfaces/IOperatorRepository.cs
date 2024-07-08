using Application.Features.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOperatorRepository: IEntityReadRepository<Operator>, IEntityRepository<Operator>
    {

        public Task<GetOperatorDTO> GetAsyncWithIncludes(Expression<Func<Operator, bool>> predicate);
        public Task<List<Operator>> GetAllAsyncWithIncludes(Expression<Func<Operator, bool>> predicate);
        public Task<List<GetOperatorDTO>> GetAllAsyncWithIncludes();
    }
}
