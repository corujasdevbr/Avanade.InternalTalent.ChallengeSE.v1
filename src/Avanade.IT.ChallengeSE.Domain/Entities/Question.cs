using Flunt.Validations;

namespace Avanade.IT.ChallengeSE.Domain.Entities
{
    public class Question : BaseEntity
    {
        public String Title { get; private set; }
        public String? Image { get; private set; }
        public Int32 Points { get; private set; }
        public Int32 Weight { get; private set; }

        public Question(String title, Int32 points, Int32 weight, Boolean active = true, String? image = null)
        {
            AddNotifications(new Contract<Question>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Question")
                .IsGreaterThan(points, 0, "Points", "Enter the Points of the Talent Comunity")
                .IsGreaterThan(weight, 0, "Weight", "Enter the Description of the Talent Comunity")
            );

            if (IsValid)
            {
                Title = title;
                Image = image;
                Points = points;
                Weight = weight;
                Active = active;
            }
        }

        public Question(Guid id, String title, Int32 points, Int32 weight, Boolean active = true, String? image = null)
        {
            AddNotifications(new Contract<Question>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Question")
                .IsGreaterThan(points, 0, "Points", "Enter the Points of the Talent Comunity")
                .IsGreaterThan(weight, 0, "Weight", "Enter the Description of the Talent Comunity")
            );

            if (IsValid)
            {
                Id = id;
                Title = title;
                Image = image;
                Points = points;
                Weight = weight;
                Active = active;
            }
        }

        public void Update(string title, int points, int weight, string? image = null)
        {
            AddNotifications(new Contract<Question>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Question")
                .IsGreaterThan(points, 0, "Points", "Enter the Points of the Talent Comunity")
                .IsGreaterThan(weight, 0, "Weight", "Enter the Description of the Talent Comunity")
            );

            if (IsValid)
            {
                Title = title;
                Image = image;
                Points = points;
                Weight = weight;
            }
        }
    }
}
