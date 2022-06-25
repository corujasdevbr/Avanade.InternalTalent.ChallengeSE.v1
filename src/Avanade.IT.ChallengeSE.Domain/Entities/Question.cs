using Avanade.IT.ChallengeSE.Domain.ValueObjects.Enumerators;
using Flunt.Validations;

namespace Avanade.IT.ChallengeSE.Domain.Entities
{
    public class Question : BaseEntity
    {
        public String Title { get; private set; }
        public String? Image { get; private set; }
        public Int32 Points { get; private set; }
        public Level Level { get; private set; }
        public ICollection<Answer> Answers { get; set; }

        public Question(String title, Int32 points, Level level, Boolean active = true, String? image = null)
        {
            AddNotifications(new Contract<Question>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Question")
                .IsGreaterThan(points, 0, "Points", "Enter the Points of the Talent Comunity")
            );

            if (IsValid)
            {
                Title = title;
                Image = image;
                Points = points;
                Level = level;
                Active = active;
            }
        }

        public Question(Guid id, String title, Int32 points, Level level, Boolean active = true, String? image = null)
        {
            AddNotifications(new Contract<Question>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Question")
                .IsGreaterThan(points, 0, "Points", "Enter the Points of the Talent Comunity")
            );

            if (IsValid)
            {
                Id = id;
                Title = title;
                Image = image;
                Points = points;
                Level = level;
                Active = active;
            }
        }

        public void Update(String title, Int32 points, Level level, String? image = null)
        {
            AddNotifications(new Contract<Question>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Question")
                .IsGreaterThan(points, 0, "Points", "Enter the Points of the Talent Comunity")
            );

            if (IsValid)
            {
                Title = title;
                Image = image;
                Points = points;
                Level = level;
            }
        }
    }
}
