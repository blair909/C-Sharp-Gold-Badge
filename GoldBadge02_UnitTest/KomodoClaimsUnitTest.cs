using System;
using System.Collections.Generic;
using GoldBadge02_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadge02_UnitTest
{
    [TestClass]
    public class KomodoClaimsUnitTest
    {
        [TestMethod]
        public void AddContentToDirectory_ShouldGetCorrectBool()
        {
            KomodoClaimsContent testContent = new KomodoClaimsContent();
            KomodoClaimsRepo repo = new KomodoClaimsRepo();

            bool addResult = repo.AddClaimToDirectory(testContent);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllDirectory_ShouldReturnCorrectList()
        {
            KomodoClaimsContent testContent = new KomodoClaimsContent();
            KomodoClaimsRepo repo = new KomodoClaimsRepo();
            repo.AddClaimToDirectory(testContent);

            Queue<KomodoClaimsContent> testList = repo.GetAllClaims();
            bool directoryHasContent = testList.Contains(testContent);
            Assert.IsTrue(directoryHasContent);
        }
        [TestMethod]
        public void LookAtNextClaim_ShouldReturnCorrectItem()
        {
            KomodoClaimsRepo repo = new KomodoClaimsRepo();
            KomodoClaimsContent testItem = new KomodoClaimsContent();
            Queue<KomodoClaimsContent> testQueue = repo.LookAtNextClaim();
            testQueue.Clear();
            repo.AddClaimToDirectory(testItem);
            testQueue.Enqueue(testItem);

            testQueue.Peek();
            bool directoryHasItem = testQueue.Contains(testItem);
            Assert.IsTrue(directoryHasItem);
        }
        [TestMethod]
        public void ProcessNextClaim_ShouldReturnCorrectDequeuedItem()
        {
            KomodoClaimsRepo repo = new KomodoClaimsRepo();
            KomodoClaimsContent testItem = new KomodoClaimsContent();
            Queue<KomodoClaimsContent> testQueue = new Queue<KomodoClaimsContent>();
            testQueue.Clear();
            testQueue.Enqueue(testItem);
            repo.ProcessNextClaim();

            testQueue.Dequeue();
            bool directoryHasItem = testQueue.Contains(testItem);
            Assert.IsFalse(directoryHasItem);
        }
    }
}
