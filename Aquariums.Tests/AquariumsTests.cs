namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        [Test]
        public void TestIfCtorWorks()
        {
            var aquarium = new Aquarium("Varna", 5);

            Assert.AreEqual("Varna", aquarium.Name);
            Assert.AreEqual(5, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void TestIfCtorThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 2));
            Assert.Throws<ArgumentException>(() => new Aquarium("Varba", -3));
        }

        [Test]
        public void TestAdd()
        {
            var aquarium = new Aquarium("Varna", 1);
            aquarium.Add(new Fish("Nemo"));
            Assert.AreEqual(1, aquarium.Count);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Ivanka")));
        }

        [Test]
        public void TestRemove()
        {
            var aquarium = new Aquarium("Varna", 1);
            aquarium.Add(new Fish("Nemo"));
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Pesho"));
            Assert.AreEqual(1, aquarium.Count);
            aquarium.RemoveFish("Nemo");
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void TestSell()
        {
            var aquarium = new Aquarium("Varna", 1);
            aquarium.Add(new Fish("Nemo"));
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Pesho"));
            Assert.AreEqual(false, aquarium.SellFish("Nemo").Available);
        }

        [Test]
        public void TestReport()
        {
            var aquarium = new Aquarium("Varna", 1);
            aquarium.Add(new Fish("Nemo"));
            Assert.That(() => aquarium.Report() == "Fish available at Varna: Nemo");
        }
    }
}
