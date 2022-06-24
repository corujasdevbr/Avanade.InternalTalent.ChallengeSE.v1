using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.ValueObjects.Enumerators;

namespace Avanade.IT.ChallengeSE.Application.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public String Title { get;  set; }
        public String? Image { get;  set; }
        public Int32 Points { get;  set; }
        public Level Level { get;  set; }
        public String LevelDescription { get; set; }
        public Boolean Active { get;  set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateAltered { get; set; }

        public QuestionDto(Guid id, String title, Int32 points, Level level,  DateTime dateCreated, DateTime dateAltered, Boolean active = true, String? image = null)
        {
            Id = id;
            Title = title;
            Image = image;
            Points = points;
            Level = level;
            Active = active;
            DateCreated = dateCreated;
            DateAltered = dateAltered;
            LevelDescription = Enum.GetName(typeof(Level), level);
        }

        public static implicit operator QuestionDto(Question question) =>
           new(question.Id,
               question.Title,
               question.Points,
               question.Level,
               question.DateCreated,
               question.DateAltered,
               question.Active,
               question.Image);

    }
}
