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

        [TestCase("1990-6-18", "Ловеч", false, 1)]
        [TestCase("2099-12-31", "Видин", true, 5)]
        [TestCase("1800-1-1", "София - град", false, 3)]
        public void GenerateShouldWorkWithFourValidParamaters(DateTime birthDate, string city, bool isMale, int birthPosition)
        {
            var result = _generator.Generate(birthDate, city, isMale, birthPosition);
            Assert.True(_generator.Validate(result));
        }

        [TestCase("1990-6-18", "Каспичан", false, 1)]
        [TestCase("2099-12-31", "Dragoman", true, 5)]
        [TestCase("1800-1-1", "Дюбай", false, 3)]
        public void GenerateShouldNotWorkWithFourParamatersAndInvalidCity(DateTime birthDate, string city, bool isMale, int birthPosition)
        {
            Assert.Throws<InvalidCityException>(() => _generator.Generate(birthDate, city, isMale, birthPosition));
        }

        [TestCase("1990-6-18", "Ловеч", false, -1)]
        [TestCase("2099-12-31", "Видин", true, 0)]
        [TestCase("1800-1-1", "София - град", false, 55)]
        public void GenerateShouldNotWorkWithFourParamatersAndInvalidBirthPosition(DateTime birthDate, string city, bool isMale, int birthPosition)
        {
            Assert.Throws<IndexOutOfRangeException>(() => _generator.Generate(birthDate, city, isMale, birthPosition));
        }

        [TestCase(1989, 6, 18, "Бургас", true, 1)]
        [TestCase(1800, 1, 1, "Пловдив", false, 5)]
        [TestCase(2099, 12, 31, "Видин", true, 2)]
        public void GenerateShouldWorkWithSixValidParamaters(int year, int month, int day, string city, bool isMale, int birthPosition)
        {
            var result = _generator.Generate(year, month, day, city, isMale, birthPosition);
            Assert.True(_generator.Validate(result));
        }

        [TestCase(09870, 6, 18, "Бургас", true, 4)]
        [TestCase(1790, 1, 1, "Пловдив", false, 4)]
        [TestCase(2999, 12, 31, "Видин", true, 2)]
        public void GenerateShouldNotWorkWithSixParamatersAndInvalidYear(int year, int month, int day, string city, bool isMale, int birthPosition)
        {
            Assert.Throws<InvalidYearException>(() => _generator.Generate(year, month, day, city, isMale, birthPosition));
        }

        [TestCase(2022, -1, 18, "Бургас", true, 4)]
        [TestCase(1990, 99, 1, "Пловдив", false, 7)]
        [TestCase(1800, 13, 31, "Видин", true, 4)]
        public void GenerateShouldNotWorkWithSixParamatersAndInvalidMonth(int year, int month, int day, string city, bool isMale, int birthPosition)
        {
            Assert.Throws<InvalidMonthException>(() => _generator.Generate(year, month, day, city, isMale, birthPosition));
        }

        [TestCase(2022, 1, 158, "Бургас", true, 1)]
        [TestCase(1990, 9, -11, "Пловдив", false, 4)]
        [TestCase(1800, 3, 33, "Видин", true, 6)]
        public void GenerateShouldNotWorkWithSixParamatersAndInvalidDay(int year, int month, int day, string city, bool isMale, int birthPosition)
        {
            Assert.Throws<InvalidDayException>(() => _generator.Generate(year, month, day, city, isMale, birthPosition));
        }

        [TestCase(1989, 6, 18, "Бургас", true, 0)]
        [TestCase(1800, 1, 1, "Пловдив", false, -1)]
        [TestCase(2099, 12, 31, "Видин", true, 55)]
        public void GenerateShouldNotWorkWithSixParamatersAndInvalidBirthPosition(int year, int month, int day, string city, bool isMale, int birthPosition)
        {
            Assert.Throws<IndexOutOfRangeException>(() => _generator.Generate(year, month, day, city, isMale, birthPosition));
        }
    }
}
