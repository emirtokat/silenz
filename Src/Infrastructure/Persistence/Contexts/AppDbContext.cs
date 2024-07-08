using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Persistence.Contexts
{
    public class AppDbContext:DbContext
    {

        protected IConfiguration? Configuration { get; set; }
        public AppDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=Alican;Database=polls_app1;TrustServerCertificate=True;Integrated Security = False; Trusted_Connection=True");
        //}
        public DbSet<Answer> answers { get; set; }
        public DbSet<QuestionOpt> question_options { get; set; }
        public DbSet<UserAnswer> user_answers { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Operator> operators { get; set; }
        public DbSet<Form> forms { get; set; }
        public DbSet<Question> form_questions { get; set; }
        public DbSet<UserOperationClaim> user_operation_claims { get; set; }
        public DbSet<OperationClaim> operation_claims { get; set; }
        public DbSet<RefreshToken> refresh_tokens { get; set; }
    }
}
