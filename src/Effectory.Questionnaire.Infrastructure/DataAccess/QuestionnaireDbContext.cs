using Effectory.Questionnaire.Domain.Questionnaires.UserResponses;
using Microsoft.EntityFrameworkCore;

namespace Effectory.Questionnaire.Infrastructure.DataAccess
{
    public class QuestionnaireDbContext : DbContext
    {
        public QuestionnaireDbContext(
            DbContextOptions<QuestionnaireDbContext> options) : base(options)
        {
        }

        public DbSet<UserResponse> UserResponses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionnaireDbContext).Assembly);
        }
    }
}