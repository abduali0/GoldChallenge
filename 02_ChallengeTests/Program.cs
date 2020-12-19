using System;

namespace _02_ChallengeTests
{
    [TestClass]
    public class Tests
    {
        private Repository _repo;
        private Claims _claims;
        private Claims _lateClaims;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new Repository();
            _claims = new Claims(1, TypeOfClaim.Car, "Broken windshield", 250, DateTime.Parse("10/05/2019"), DateTime.Parse("02/25/2020"), true);
            _lateClaims = new Claims(1, TypeOfClaim.Theft, "Stolen purse", 125, DateTime.Parse("05/23/2020"), DateTime.Parse("11/04/2020"), false);
        }

        [TestMethod]
        public void POCOsTest()
        {
            Claims newClaim = new Claims(2, TypeOfClaim.Home, "Hail damage", 650, DateTime.Parse("03/21/2020"), DateTime.Parse("06/27/2020"), true);

            Assert.AreEqual(2, newClaim.ClaimID);
            Assert.AreEqual(TypeOfClaim.Home, newClaim.ClaimType);
            Assert.AreEqual("Hail damage", newClaim.Description);
            Assert.AreEqual(DateTime.Parse("02/28/2020"), newClaim.DateOfIncident);
            Assert.AreEqual(DateTime.Parse("03/27/2020"), newClaim.DateOfClaim);
            Assert.AreEqual(true, newClaim.IsValid);
        }

        [TestMethod]
        public void AddClaimTest()
        {
            _repo.AddClaim(_claims);

            int expected = 1;
            int actual = _repo.GetList().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void RemoveClaimTest()
        {
            Repository content = new Repository();

        }

        [TestMethod]
        public void ValidTestTrue()
        {
            _repo.AddClaim(_claims);

            bool expected = true;
            bool actual = _claims.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidTestFalse()
        {
            _repo.AddClaim(_lateClaims);

            bool expected = false;
            bool actual = _lateClaims.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetListTest()
        {
            _repo.GetList();
            Assert.IsNotNull(_repo);

        }
    }
}