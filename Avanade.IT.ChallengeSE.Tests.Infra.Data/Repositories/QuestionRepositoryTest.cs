using Avanade.IT.ChallengeSE.Domain.Entities;
using Avanade.IT.ChallengeSE.Domain.Interfaces.Repositories;
using Avanade.IT.ChallengeSE.Domain.ValueObjects.Enumerators;
using Avanade.IT.ChallengeSE.Infra.Data.Repositories;
using Avanade.IT.ChallengeSE.Tests.Infra.Data.Context;
using Bogus;
using Microsoft.Extensions.Logging;
using Moq;

namespace Avanade.IT.ChallengeSE.Tests.Infra.Data.Repositories
{
    public class QuestionRepositoryTest : IClassFixture<DbTcContextInMemoryTest>
    {
        private readonly DbTcContextInMemoryTest _fixture;
        private readonly IQuestionRepository _questionRepository;
        private readonly Mock<ILogger<QuestionRepository>> _logger;
        private readonly Faker<Question> _fakerQuestion;

        public QuestionRepositoryTest()
        {
            _fakerQuestion = new Faker<Question>("pt_BR");
            _fixture = new DbTcContextInMemoryTest();
            _logger = new Mock<ILogger<QuestionRepository>>();
            _questionRepository = new QuestionRepository(_fixture._context, _logger.Object);
        }

        [Fact]
        public void Valid_Return_List_Questions()
        {
            var result = _questionRepository.GetAll();

            Assert.Equal(2, result.ToList().Count);
        }

        [Fact]
        public void Valid_Add_Question()
        {
            var testQuestion = _fakerQuestion
                                       .StrictMode(false)
                                       .RuleFor(p => p.Title, u => u.Lorem.Sentence())
                                       .RuleFor(p => p.Image, u => u.Image.People().ToLower())
                                       .RuleFor(p => p.Points, u => u.Random.Number(1, 5))
                                       .RuleFor(p => p.Level, u => (Level)u.Random.Number(1, 3));

            var question = testQuestion.Generate();

            var result = _questionRepository.Add(question);

            Assert.Equal(result, question);
        }


        [Fact]
        public void Valid_Edit_Question() 
        {
            var question = _fakerQuestion
                                       .StrictMode(false)
                                       .RuleFor(p => p.Title, u => u.Lorem.Sentence())
                                       .RuleFor(p => p.Image, u => u.Image.People().ToLower())
                                       .RuleFor(p => p.Points, u => u.Random.Number(1, 5))
                                       .RuleFor(p => p.Level, u => (Level)u.Random.Number(1, 3)).Generate();

            var questionEdit = _questionRepository.GetAll().FirstOrDefault();

            questionEdit?.Update(question.Title, question.Points, question.Level, question.Image);
            
            var result = _questionRepository.Update(questionEdit);

            Assert.Equal(result, questionEdit);
        }


        [Fact]
        public void Valid_Active_Question()
        {
            var questionEdit = _questionRepository.GetAll().FirstOrDefault();

            questionEdit.ChangeStatus();

            var result = _questionRepository.Update(questionEdit);

            Assert.True(questionEdit.Active);
        }

    }
}
