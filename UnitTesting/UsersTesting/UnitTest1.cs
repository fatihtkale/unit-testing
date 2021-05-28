using System.Collections.Generic;
using NUnit.Framework;
using Users;

namespace User.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void StartTest()
        {
            DbContext.SetStudent("Peter", "Niels", 24);
            DbContext.SetStudent("Niels", "Madsen", 23);
            DbContext.SetStudent("Brian", "Nyakgnsaigjgs", 22);
            DbContext.SetStudent("Fatih", "Toprakkale", 20);
        }

        [Test]
        public void GetAllUsersReturnList()
        {
            List<Users.Model.User> users = DbContext.GetStudents();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(users);
        }

        [TestCase("Klaus", "Sørensen", 20)]
        [TestCase("Lars", "Larsen", 23)]
        [TestCase("Xd", "hi", 26)]
        public void SetUsersReturnList(string navn, string efternavn, int alder)
        {
            List<Users.Model.User> users = DbContext.SetStudent(navn,efternavn,alder);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(users);
        }
        
        [TestCase("Peter")]
        [TestCase("Xd")]
        [TestCase("Lars")]
        [TestCase("Niels")]
        [TestCase("Fatih")]
        [TestCase("Klaus")]
        public void DeleteUsersReturnList(string navn)
        {
            List<Users.Model.User> users = DbContext.DeleteStudent(navn);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(users);
        }
    }
}
