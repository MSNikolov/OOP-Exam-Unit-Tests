using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aquariums.Tests
{
    public class FishTests
    {
        [Test]
        public void TestCtor()
        {
            var fish = new Fish("Nemo");
            Assert.AreEqual("Nemo", fish.Name);
            Assert.AreEqual(true, fish.Available);
        }
    }
}
