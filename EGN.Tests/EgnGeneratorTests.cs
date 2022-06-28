using EGN.Models;
using NUnit.Framework;

namespace EGN.Tests
{
    public class EgnGeneratorTests
    {
        private Egn _generator;

        [SetUp]
        public void Initialize()
        {
            _generator = new Egn();
        }

        public void GenerateShouldWorkWithThreeValidParamaters()
        {

        }


        [TestCase(1989, 6, 18, "Бургас", true)]
        [TestCase(1800, 1, 1, "Пловдив", false)]
        [TestCase(2099, 12, 31, "Видин", true)]
        public void GenerateShouldWorkWithFiveValidParamaters(int year, int month, int day, string city, bool isMale)
        {
            var result = _generator.Generate(year, month, day, city, isMale);
            Assert.True(_generator.Validate(result));
        }
    }
}
