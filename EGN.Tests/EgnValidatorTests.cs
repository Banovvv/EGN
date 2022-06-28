using EGN.Models;
using NUnit.Framework;

namespace EGN.Tests
{
    [TestFixture]
    public class EgnValidatorTests
    {
        private Egn _validator;

        [SetUp]
        public void Initialize()
        {
            _validator = new Egn();
        }

        #region ValidationTests
        [TestCase("9206183026")]
        [TestCase("7524169268")]
        [TestCase("7501010010")]
        public void ValidateShouldWorkWithValidEgn(string egn)
        {
            var result = _validator.Validate(egn);
            Assert.True(result);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("0000000000")]
        [TestCase("9999999999")]
        [TestCase("92061830")]
        [TestCase("7523")]
        [TestCase("acbd1234")]
        [TestCase("qwaserast")]
        [TestCase("acbd1234xx")]
        [TestCase("qwaserasdx")]
        [TestCase("9206183026912")]
        [TestCase("75234145111123312")]
        [TestCase("acbd12331dadaada4")]
        [TestCase("qwasedddddadarasdada123t")]
        public void ValidateShouldNotWorkWithInvalidEgn(string egn)
        {
            var result = _validator.Validate(egn);
            Assert.False(result);
        }
        #endregion
    }
}
