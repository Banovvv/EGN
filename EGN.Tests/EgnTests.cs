using EGN.Models;
using NUnit.Framework;

namespace EGN.Tests
{
    [TestFixture]
    public class EgnTests
    {
        #region ValidationTests
        [Test]
        [TestCase("9206183026")]
        [TestCase("7524169268")]
        [TestCase("7501010010")]
        public void ValidateShouldWorkWithValidEgn(string egn)
        {
            var egnValidator = new Egn();
            var result = egnValidator.Validate(egn);
            Assert.True(result);
        }

        [Test]
        [TestCase("0000000000")]
        [TestCase("9999999999")]
        public void ValidateShouldNotWorkWithInvalidEgn(string egn)
        {
            var egnValidator = new Egn();
            var result = egnValidator.Validate(egn);
            Assert.False(result);
        }

        [Test]
        [TestCase("acbd1234xx")]
        [TestCase("qwaserasdx")]
        public void ValidateShouldNotWorkWithNonNumericEgn(string egn)
        {
            var egnValidator = new Egn();
            var result = egnValidator.Validate(egn);
            Assert.False(result);
        }

        [Test]
        [TestCase("92061830")]
        [TestCase("7523")]
        [TestCase("acbd1234")]
        [TestCase("qwaserast")]
        public void ValidateShouldNotWorkWithShorterEgn(string egn)
        {
            var egnValidator = new Egn();
            var result = egnValidator.Validate(egn);
            Assert.False(result);
        }

        [Test]
        [TestCase("9206183026912")]
        [TestCase("75234145111123312")]
        [TestCase("acbd12331dadaada4")]
        [TestCase("qwasedddddadarasdada123t")]
        public void ValidateShouldNotWorkWithLongerEgn(string egn)
        {
            var egnValidator = new Egn();
            var result = egnValidator.Validate(egn);
            Assert.False(result);
        }
        #endregion
    }
}
