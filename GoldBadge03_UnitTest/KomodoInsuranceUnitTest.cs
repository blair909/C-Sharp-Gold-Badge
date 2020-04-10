using System;
using System.Collections.Generic;
using GoldBadge03_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadge03_UnitTest
{
    [TestClass]
    public class KomodoInsuranceUnitTest
    {
        [TestMethod]
        public void AddContentToDirectory_ShouldGetCorrectBool()
        {
            KomodoInsuranceContent content = new KomodoInsuranceContent();
            KomodoInsuranceRepo repo = new KomodoInsuranceRepo();

            bool addResult = repo.CreateNewBadge(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllDirectory_ShouldReturnCorrectList()
        {
            KomodoInsuranceContent testContent = new KomodoInsuranceContent();
            KomodoInsuranceRepo repo = new KomodoInsuranceRepo();
            repo.CreateNewBadge(testContent);

            List<KomodoInsuranceContent> testList = repo.GetAllKeysAndValues();
            bool directoryHasContent = testList.Contains(testContent);
            Assert.IsTrue(directoryHasContent);
        }
        public KomodoInsuranceContent _content;
        public KomodoInsuranceRepo _kirepo;
        [TestInitialize]
        public void Arrange()
        {
            _kirepo = new KomodoInsuranceRepo();
            _content = new KomodoInsuranceContent(9, "Derp");
            _kirepo.CreateNewBadge(_content);
        }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            KomodoInsuranceContent toBeDeleted = _kirepo.GetContentByBadgeID(9);

            bool removeResult = _kirepo.DeleteExistingBadgeValue(toBeDeleted);
            Assert.IsTrue(removeResult);
        }
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            KomodoInsuranceContent newContent = new KomodoInsuranceContent(27, "Derpo");
            bool updateResult = _kirepo.AddOrUpdateDictionaryEntry(9, newContent);
            Assert.IsTrue(updateResult);
        }
    }
}
