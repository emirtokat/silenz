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

    public class QuestionOptRepository : BaseRepository<QuestionOpt>, IQuestionOptRepository
    {
        private readonly AppDbContext _context;

        public QuestionOptRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
