using Application.Features.Dtos;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFormRepository: IEntityReadRepository<Form>, IEntityRepository<Form>
    {
        public Task<Form> GetAsyncWithIncludes(Expression<Func<Form, bool>> predicate);
        public Task<List<Form>> GetAllAsyncWithIncludes(Expression<Func<Form, bool>> predicate);
        public Task<List<GetFormDTO>> GetAllAsyncWithIncludes();

    }
}
