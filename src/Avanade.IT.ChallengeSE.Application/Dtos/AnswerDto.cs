using Avanade.IT.ChallengeSE.Domain.Entities;

namespace Avanade.IT.ChallengeSE.Application.Dtos
{
    public class AnswerDto
    {
        public Guid Id { get; set; }
        public String Title { get;  set; }
        public String? Image { get;  set; }
        public Boolean Correct { get;  set; }
        public Guid IdQuestion { get; set; }
        public QuestionDto? Question { get; set; } = null;
        public Boolean Active { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateAltered { get; set; }
    }
}
