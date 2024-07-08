using Application.Features.Dtos;
using Application.Interfaces;
using Dapper;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Persistence.Repositories
{

    public class FormRepository : BaseRepository<Form>, IFormRepository
    {
        private readonly AppDbContext _context;
        internal readonly DbSet<Form> _entity;
        public FormRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _entity = _context.Set<Form>();
        }
        public async Task<Form> GetAsyncWithIncludes(Expression<Func<Form, bool>> predicate) {

            IQueryable<Form> query = _entity;
            query = query.Where(predicate).Include(f=>f.Operator).Include(f => f.Questions).ThenInclude(f => f.QuestionOpts);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<List<Form>> GetAllAsyncWithIncludes(Expression<Func<Form, bool>> predicate)
        {
            IQueryable<Form> query = _entity;
            query = query.Where(predicate).Include(f => f.Operator);
            return await query.ToListAsync();
        }
        public async Task<List<GetFormDTO>> GetAllAsyncWithIncludes()
        {
            IQueryable<Form> query = _entity;
            var dto= query.Include(f => f.Operator).ThenInclude(o => o.User).Select(f=> new GetFormDTO
            {
                ID = f.Id,
                Title = f.Title,
                UserID = f.Operator.UserId,
                Firstname = f.Operator.User.FirstName,
                Lastname = f.Operator.User.LastName,
            });
            return await dto.ToListAsync();

            
        }
    }
}
