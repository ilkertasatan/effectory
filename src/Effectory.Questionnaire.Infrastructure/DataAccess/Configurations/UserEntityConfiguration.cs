using Effectory.Questionnaire.Domain.Questionnaires.UserResponses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Effectory.Questionnaire.Infrastructure.DataAccess.Configurations
{
    public sealed class UserEntityConfiguration : IEntityTypeConfiguration<UserResponse>
    {
        public void Configure(EntityTypeBuilder<UserResponse> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId);
            builder.Property(x => x.DepartmentId);
            builder.Property(x => x.QuestionnaireId);
            builder.Property(x => x.QuestionId);
            builder.Property(x => x.AnswerId);
            builder.Property(x => x.RespondedAt);
        }
    }
}