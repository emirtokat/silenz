using Application.Features.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class OperatorRepository : BaseRepository<Operator>, IOperatorRepository
    {
        private readonly AppDbContext _context;
        internal readonly DbSet<Operator> _entity;
        public OperatorRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _entity = _context.Set<Operator>();
        }
        public async Task<List<Operator>> GetAllAsyncWithIncludes(Expression<Func<Operator, bool>> predicate)
        {
            IQueryable<Operator> query = _entity;
            query = query.Where(predicate).Include(o => o.Forms);
            return await query.ToListAsync();
        }

        public async Task<List<GetOperatorDTO>> GetAllAsyncWithIncludes()
        {
            IQueryable<Operator> query = _entity;
            query = query.Include(o => o.Forms);
            var dto = query.Include(o => o.User).Include(o => o.Forms).Select(d => new GetOperatorDTO
            {
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                Forms = d.Forms
            });
            return await dto.ToListAsync();
        }

        public async Task<GetOperatorDTO> GetAsyncWithIncludes(Expression<Func<Operator, bool>> predicate)
        {
            IQueryable<Operator> query = _entity;
            var dto = query.Where(predicate).Include(o=>o.User).Include(o => o.Forms).Select(d => new  GetOperatorDTO
            {
                FirstName = d.User.FirstName,
                LastName= d.User.LastName,
                Forms = d.Forms
            });
            return await dto.FirstOrDefaultAsync();
        }
    }
}
