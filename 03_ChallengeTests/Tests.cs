using System;
using System.Collections.Generic;
using _03_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_ChallengeTests
{
    [TestClass]
    public class Tests
    {
        private Repository _repo;
        private BadgeNum _badges;

        [TestInitialize]
        public void Initialize()
        {
            List<string> list = new List<string>();
            list.Add("door_1");

            _repo = new Repository();
            _badges = new BadgeNum(700, list);
        }
    }
} 
