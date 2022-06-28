using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using Avanade.IT.ChallengeSE.Infra.Data.Repositories;
using Avanade.IT.ChallengeSE.Tests.Infra.Data.Context;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;

namespace Avanade.IT.ChallengeSE.Tests.Infra.Data.Repositories
{
    public class AnswerRepositoryTest : IClassFixture<DbTcContextInMemoryTest>
    {
        private readonly DbTcContextInMemoryTest _fixture;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly Mock<ILogger<AnswerRepository>> _loggerAnswer;
        private readonly Mock<ILogger<QuestionRepository>> _loggerQuestion;
        private readonly Faker<Answer> _fakerAnswer;

        public AnswerRepositoryTest()
        {
            _fakerAnswer = new Faker<Answer>("pt_BR");
            _fixture = new DbTcContextInMemoryTest();

            _loggerAnswer = new Mock<ILogger<AnswerRepository>>();
            _loggerQuestion = new Mock<ILogger<QuestionRepository>>();

            _answerRepository = new AnswerRepository(_fixture._context, _loggerAnswer.Object);
            _questionRepository = new QuestionRepository(_fixture._context, _loggerQuestion.Object);
        }


        [Fact]
        public void Valid_Add_Answer()
        {
            var testAnswer = _fakerAnswer
                                       .StrictMode(false)
                                       .RuleFor(p => p.Title, u => u.Lorem.Sentence())
                                       .RuleFor(p => p.Image, u => u.Image.People().ToLower())
                                       .RuleFor(p => p.Correct, u => u.Random.Bool())
                                       .RuleFor(p => p.Active, true).Generate();

            var result = _questionRepository.GetAll().FirstOrDefault();

            var resultAnswer = _answerRepository.Add(new Answer(testAnswer.Title, result.Id, testAnswer.Correct, testAnswer.Active, testAnswer.Image));

            Assert.Equal(testAnswer.Title, resultAnswer.Title);
        }

    }
}
