using EGN.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGN.Tests
{
    [TestFixture]
    public class EgnInfoTests
    {
        [TestCase("9226183041", "Ловеч", "мъж", 2)]
        public void ConstructorShouldWorkWithValidParameters(string egn, string region, string gender, int birthPosition)
        {
            var egnInfo = new EgnInfo(egn, region, gender, birthPosition);

            Assert.AreEqual(egn, egnInfo.Egn);
            Assert.AreEqual("събота, 18 юни 1892", egnInfo.BirthDate);
            Assert.AreEqual(region, egnInfo.Region);
            Assert.AreEqual(gender, egnInfo.Gender);
            Assert.AreEqual(birthPosition, egnInfo.BirthPosition);
        }
    }
}
