using Flunt.Validations;

namespace Avanade.IT.ChallengeSE.Domain.Entities
{
    public class Answer : BaseEntity
    {
        public String Title { get; private set; }
        public String? Image { get; private set; }
        public Boolean Correct { get; private set; }
        public Guid IdQuestion { get; private set; }
        public Question Question { get; private set; }

        public Answer(String title, Guid idQuestion, Boolean correct, Boolean active = true, String? image = null)
        {
            AddNotifications(new Contract<Answer>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Answer")
            );

            if (IsValid)
            {
                Title = title;
                Image = image;
                IdQuestion = idQuestion;
                Correct = correct;
                Active = active;
            }
        }


        public Answer(Guid id, String title, Guid idQuestion, Boolean correct, Boolean active = true, String? image = null)
        {
            AddNotifications(new Contract<Question>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Question")
            );

            if (IsValid)
            {
                Id = id;
                Title = title;
                Image = image;
                IdQuestion = idQuestion;
                Correct = correct;
                Active = active;
            }
        }

        public void Update(String title, Boolean correct, Guid idQuestion, String? image = null)
        {
            AddNotifications(new Contract<Answer>()
                .Requires()
                .IsNotNullOrEmpty(title, "Title", "Enter the Title of the Answer")
            );

            if (IsValid)
            {
                Title = title;
                Image = image;
                IdQuestion = idQuestion;
                Correct = correct;
            }
        }
    }
}
