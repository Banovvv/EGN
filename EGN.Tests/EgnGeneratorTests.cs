using EGN.Exceptions;
using EGN.Models;
using NUnit.Framework;
using System;

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

        [TestCase("1990-6-18", "Ловеч", false)]
        [TestCase("2099-12-31", "Видин", true)]
        [TestCase("1800-1-1", "София - град", false)]
        public void GenerateShouldWorkWithThreeValidParamaters(DateTime birthDate, string city, bool isMale)
        {
            var result = _generator.Generate(birthDate, city, isMale);
            Assert.True(_generator.Validate(result));
        }

        [TestCase(1989, 6, 18, "Бургас", true)]
        [TestCase(1800, 1, 1, "Пловдив", false)]
        [TestCase(2099, 12, 31, "Видин", true)]
        public void GenerateShouldWorkWithFiveValidParamaters(int year, int month, int day, string city, bool isMale)
        {
            var result = _generator.Generate(year, month, day, city, isMale);
            Assert.True(_generator.Validate(result));
        }

        [TestCase(09870, 6, 18, "Бургас", true)]
        [TestCase(1790, 1, 1, "Пловдив", false)]
        [TestCase(2999, 12, 31, "Видин", true)]
        public void GenerateShouldNotWorkWithFiveParamatersAndInvalidYear(int year, int month, int day, string city, bool isMale)
        {
            Assert.Throws<InvalidYearException>(() => _generator.Generate(year, month, day, city, isMale));
        }

        [TestCase(2022, -1, 18, "Бургас", true)]
        [TestCase(1990, 99, 1, "Пловдив", false)]
        [TestCase(1800, 13, 31, "Видин", true)]
        public void GenerateShouldNotWorkWithFiveParamatersAndInvalidMonth(int year, int month, int day, string city, bool isMale)
        {
            Assert.Throws<InvalidMonthException>(() => _generator.Generate(year, month, day, city, isMale));
        }

        [TestCase(2022, 1, 158, "Бургас", true)]
        [TestCase(1990, 9, -11, "Пловдив", false)]
        [TestCase(1800, 3, 33, "Видин", true)]
        public void GenerateShouldNotWorkWithFiveParamatersAndInvalidMDay(int year, int month, int day, string city, bool isMale)
        {
            Assert.Throws<InvalidDayException>(() => _generator.Generate(year, month, day, city, isMale));
        }
    }
}
