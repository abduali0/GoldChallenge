using System;

namespace _01_ChallengeTests
{
    [TestClass]
    public class Tests
    {
        private Repository _contentRepo;
        private FoodMenu _content;

        [TestInitialize]
        public void Initialize()
        {
            _contentRepo = new Repository();
            _content = new Menu(5, "McChicken", "A plain old chicken sandwich from McDonalds", "2 Buns, 1 Chicken Breast, Mayo");
        }

        [TestMethod]
        public void AddContentToList()
        {
            _contentRepo.AddOrder(_content);

            int expected = 1;
            int actual = _contentRepo.ListOrders().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveContentFromList()
        {
            Repository contentRepo = new Repository();

            contentRepo.AddOrder(_content);

            bool wasRemoved = contentRepo.RemoveOrder(_content);
            Assert.IsTrue(wasRemoved);
        }

        [TestMethod]
        public void POCOTest()
        {
            Menu neworder = new Menu(1, "Cheeseburger", "Plain old burger", "2 buns, 1 patty");

            Assert.AreEqual(1, neworder.ItemNumber);
            Assert.AreEqual("Cheeseburger", neworder.Name);
            Assert.AreEqual("Plain old burger", neworder.Desc);
            Assert.AreEqual("2 buns, 1 patty", neworder.Ingredients);
        }
    }
}