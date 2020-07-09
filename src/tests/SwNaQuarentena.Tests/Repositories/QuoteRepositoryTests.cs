using Moq;
using NUnit.Framework;
using SwNaQuarentena.Api.Repositories;

namespace SwNaQuarentena.Tests
{
    public class QuoteRepositoryTests
    {
        private Mock<IQuoteRepository> mockQuoteRepository = null;

        [SetUp]
        public void Setup()
        {
            mockQuoteRepository = new Mock<IQuoteRepository>();
        }

        [Test]
        public void ShouldReturnEmptyIfThereIsNoQuoteForAPersonName()
        {
            string name = "coxinha";
            mockQuoteRepository
                .Setup(s => s.GetAQuoteByPersonName(name))
                .Returns(string.Empty);

            var result = mockQuoteRepository.Object.GetAQuoteByPersonName(name);

            Assert.IsEmpty(result);
        }

        [Test]
        public void ShouldReturnAQuoteIfThereIsAQuoteForAPersonName()
        {
            string name = "carlao";
            string quote = "Vamo jogar golf!";

            mockQuoteRepository
                .Setup(s => s.GetAQuoteByPersonName(name))
                .Returns(quote);

            var result = mockQuoteRepository.Object.GetAQuoteByPersonName(name);

            Assert.AreEqual(result, quote);
        }
    }
}