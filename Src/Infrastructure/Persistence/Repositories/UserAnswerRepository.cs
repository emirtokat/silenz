using Application.Interfaces;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    public class UserAnswerRepository : BaseRepository<UserAnswer>, IUserAnswerRepository
    {
        private readonly AppDbContext _context;

        public UserAnswerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
