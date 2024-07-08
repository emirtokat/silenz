using Application.Interfaces;
using Core.Persistence.Repositories;
using Dapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReadRepository<TEntity> : IEntityReadRepository<TEntity> where TEntity : Entity
    {
        internal readonly AppDbContext _context;
        internal readonly DbSet<TEntity> _entity;
        private readonly DbConnection _sqlConnection;
        public ReadRepository(AppDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
            _sqlConnection = _context.Database.GetDbConnection();
        }
        public async Task<bool> AnyAsnc(Expression<Func<TEntity, bool>> predicate) => await _entity.AnyAsync(predicate);
        public async Task<bool> AnyAsync(string sqlCommand, object param) => await _sqlConnection.QueryFirstOrDefaultAsync<int>(sqlCommand, param) > 0;
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate) => await _entity.CountAsync(predicate);
        public async Task<int> CountAsync(string sqlCommand, object param) => await _sqlConnection.QueryFirstOrDefaultAsync<int>(sqlCommand, param);
        public async Task<int> ExecuteAsync(string command, params object[] paramaters) => await _sqlConnection.ExecuteAsync(command, paramaters);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate) => await _entity.FirstOrDefaultAsync(predicate);
        
        public async Task<TResult> GetAsync<TResult>(string sqlCommand, object param) => await _sqlConnection.QueryFirstOrDefaultAsync<TResult>(sqlCommand, param);
        public async Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return await _entity.Where(predicate).Select(selector).FirstOrDefaultAsync();
        }
        public async Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entity;
            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);
            return await query.Where(predicate).Select(selector).FirstOrDefaultAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id) => await _entity.FindAsync(id);
        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null) return await _entity.ToListAsync();
            return await _entity.Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector)
        {
            return await _entity.Where(predicate).Select(selector).ToListAsync();
        }
        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(string sqlCommand, object param) => await _sqlConnection.QueryAsync<TResult>(sqlCommand, param);
        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entity;
            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);
            return await query.Where(predicate).Select(selector).ToListAsync();
        }
    }
}
