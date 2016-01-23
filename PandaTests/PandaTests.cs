namespace Panda.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass()]
    public class PandaTests
    {
        private readonly Panda defaultPanda = new Panda("goshko", "email@gmail.com", Gender.Male);

        [TestMethod()]
        public void PandaTest()
        {
            Assert.AreEqual(defaultPanda, new Panda("goshko","email@gmail.com",Gender.Male));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(defaultPanda.ToString(), "goshko");
        }

        [TestMethod()]
        public void GetHashCodeTestEquals()
        {
            Assert.AreEqual(defaultPanda, new Panda("goshko", "email@gmail.com", Gender.Male));
        }

        [TestMethod()]
        public void GetHashCodeTestNotEquals()
        {
            Assert.AreNotEqual(defaultPanda, new Panda("goshko", "email@gmail.com", Gender.Female));
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.IsTrue(defaultPanda.Equals(new Panda("goshko", "email@gmail.com", Gender.Male)));
        }

        [TestMethod()]
        public void NotEqualsTest()
        {
            Assert.IsFalse(defaultPanda.Equals(new Panda("goshko", "email@gmail.com", Gender.Female)));
        }

        [TestMethod(),ExpectedException(typeof(ArgumentNullException))]
        public void NullParameters()
        {
            var panda = new Panda("as", null, Gender.Male);
        }
    }
}