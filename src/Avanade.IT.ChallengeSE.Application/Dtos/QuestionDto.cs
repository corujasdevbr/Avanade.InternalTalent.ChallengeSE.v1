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
        public ICollection<AnswerDto> Answers { get; set; }

        public QuestionDto() => LevelDescription = Enum.GetName(typeof(Level), Level);
    }
}
