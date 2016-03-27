namespace SocialNetwork.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Panda;
    using System.Text;
    using System.Threading.Tasks;

    using Exceptions;

    [TestClass()]
    public class SocialNetworkTests
    {
        [TestMethod(), ExpectedException(typeof(PandasAlreadyExists))]
        public void AddPandaWhenPandaExists()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            socialnetwork.AddPanda(panda);
            socialnetwork.AddPanda(new Panda("goshko", "goshko@gmail.com", Gender.Male));
        }

        [TestMethod()]
        public void HasPandaWhenItTrue()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            socialnetwork.AddPanda(panda);
            Assert.IsTrue(socialnetwork.HasPanda(new Panda("goshko", "goshko@gmail.com", Gender.Male)));
        }

        [TestMethod()]
        public void HasPandaWhenItdoesNot()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            socialnetwork.AddPanda(panda);
            Assert.IsFalse(socialnetwork.HasPanda(new Panda("NOTgoshko", "goshko@gmail.com", Gender.Male)));
        }

        [TestMethod(), ExpectedException(typeof(PandasAlreadyFriendsException))]
        public void MakeFriendsTestWhenAlreadyFriends()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            Panda panda2 = new Panda("goshko2", "goshko@gmail.com", Gender.Male);
            socialnetwork.AddPanda(panda);
            socialnetwork.AddPanda(panda2);
            socialnetwork.MakeFriends(panda, panda2);
            socialnetwork.MakeFriends(panda2, panda);
        }

        [TestMethod(), ExpectedException(typeof(PandasMustBeDifferentException))]
        public void MakeSamePandaFriends()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            socialnetwork.AddPanda(panda);
            socialnetwork.MakeFriends(panda, panda);
        }

        [TestMethod()]
        public void AreFriendTestWhenFriends()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            Panda panda2 = new Panda("goshko2", "goshko@gmail.com", Gender.Male);
            socialnetwork.AddPanda(panda);
            socialnetwork.AddPanda(panda2);
            socialnetwork.MakeFriends(panda, panda2);
            Assert.IsTrue(socialnetwork.AreFriends(panda, panda2));
        }

        [TestMethod()]
        public void AreFriendWhenNotFriends()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            Panda panda2 = new Panda("goshko2", "goshko@gmail.com", Gender.Male);
            socialnetwork.AddPanda(panda);
            socialnetwork.AddPanda(panda2);
            Assert.IsFalse(socialnetwork.AreFriends(panda, panda2));
        }

        [TestMethod()]
        public void FriendsOfTest()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            Panda panda2 = new Panda("goshko2", "goshko@gmail.com", Gender.Male);
            Panda panda3 = new Panda("goshko3", "goshko@gmail.com", Gender.Male);
            Panda panda4 = new Panda("goshko4", "goshko4@gmail.com", Gender.Male);

            socialnetwork.MakeFriends(panda, panda2);
            socialnetwork.MakeFriends(panda, panda3);
            socialnetwork.MakeFriends(panda,panda4);
            List<IPanda> friends = socialnetwork.FriendsOf(panda).ToList();
            var expected = new List<IPanda> { panda2, panda3, panda4 };
            Assert.IsTrue(Enumerable.SequenceEqual(expected.OrderBy(x => x.Name), friends.OrderBy(y => y.Name)));
        }

        [TestMethod()]
        public void ConnectionLevel2()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            Panda panda2 = new Panda("goshko2", "goshko@gmail.com", Gender.Male);
            Panda panda3 = new Panda("goshko3", "goshko@gmail.com", Gender.Male);

            socialnetwork.MakeFriends(panda, panda2);
            socialnetwork.MakeFriends(panda2, panda3);
            Assert.AreEqual(socialnetwork.ConnectionLevel(panda, panda3), 2);
        }

        [TestMethod()]
        public void ConnectionLevel3()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            Panda panda2 = new Panda("goshko2", "goshko@gmail.com", Gender.Male);
            Panda panda3 = new Panda("goshko3", "goshko@gmail.com", Gender.Male);
            Panda panda4 = new Panda("goshko4", "goshko4@gmail.com", Gender.Female);

            socialnetwork.MakeFriends(panda, panda2);
            socialnetwork.MakeFriends(panda2, panda3);
            socialnetwork.MakeFriends(panda3, panda4);
            Assert.AreEqual(socialnetwork.ConnectionLevel(panda2, panda3), 1);
        }

        [TestMethod()]
        public void ConnectionLevel4()
        {
            SocialNetwork socialnetwork = new SocialNetwork();
            Panda panda = new Panda("goshko", "goshko@gmail.com", Gender.Male);
            Panda panda2 = new Panda("goshko2", "goshko@gmail.com", Gender.Male);
            Panda panda3 = new Panda("goshko3", "goshko@gmail.com", Gender.Male);
            Panda panda4 = new Panda("goshko4", "goshko4@gmail.com", Gender.Female);
            Panda panda5 = new Panda("goshko5", "goshko5@gmail.com", Gender.Female);

            socialnetwork.MakeFriends(panda, panda2);
            socialnetwork.MakeFriends(panda2, panda3);
            socialnetwork.MakeFriends(panda3, panda4);
            socialnetwork.MakeFriends(panda4, panda5);
            Assert.AreEqual(socialnetwork.ConnectionLevel(panda4, panda2), 2);
        }
    }
}