using EGN.Models;
using NUnit.Framework;

namespace EGN.Tests
{
    [TestFixture]
    public class EgnTests
    {
        [Test]
        [TestCase("7524169268")]
        [TestCase("7501010010")]
        public void ValidateShouldWorkWithValidEgn(string egn)
        {
            var egnValidator = new Egn();
            var result = egnValidator.Validate(egn);
            Assert.True(result);
        }
    }
}
