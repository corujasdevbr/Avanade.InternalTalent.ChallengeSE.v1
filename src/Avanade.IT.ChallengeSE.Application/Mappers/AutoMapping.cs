using AutoMapper;
using Avanade.IT.ChallengeSE.Application.Commands.PostAnswerCommand;
using Avanade.IT.ChallengeSE.Application.Commands.PostQuestionCommand;
using Avanade.IT.ChallengeSE.Application.Commands.PutAnswerCommand;
using Avanade.IT.ChallengeSE.Application.Commands.PutQuestionCommand;
using Avanade.IT.ChallengeSE.Application.Dtos;
using Avanade.IT.ChallengeSE.Domain.Entities;

namespace Avanade.IT.ChallengeSE.Application.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<PostAnswerRequest, Answer>().ReverseMap();
            CreateMap<PutAnswerRequest, Answer>().ReverseMap();
            CreateMap<AnswerDto, Answer>().ReverseMap();


            CreateMap<PostQuestionRequest, Question>().ReverseMap();
            CreateMap<PutQuestionRequest, Question>().ReverseMap();
            CreateMap<QuestionDto, Question>().ReverseMap();
        }
    }
}
