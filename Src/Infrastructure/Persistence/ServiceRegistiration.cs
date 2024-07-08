using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceInfrastructer(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
            services.AddTransient(typeof(IEntityReadRepository<>), typeof(ReadRepository<>));
            services.AddTransient(typeof(IEntityRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IQuestionOptRepository, QuestionOptRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IOperatorRepository,OperatorRepository>();
            services.AddTransient<IAnswerRepository,AnswerRepository>();
            services.AddTransient<IFormRepository,FormRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IUserAnswerRepository,UserAnswerRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        }
    }
}
