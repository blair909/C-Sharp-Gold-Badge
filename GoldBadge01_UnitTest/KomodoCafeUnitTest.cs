using System;
using System.Collections.Generic;
using GoldBadge01_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadge01_UnitTest
{
    [TestClass]
    public class KomodoCafeUnitTest
    {
        [TestMethod]
        public void AddContentToDirectory_ShouldGetCorrectBool()
        {
            KomodoCafeContent content = new KomodoCafeContent();
            KomodoCafeRepo repo = new KomodoCafeRepo();

            bool addResult = repo.AddContentToDirectory(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetAllDirectory_ShouldReturnCorrectList()
        {
            KomodoCafeContent testContent = new KomodoCafeContent();
            KomodoCafeRepo repo = new KomodoCafeRepo();
            repo.AddContentToDirectory(testContent);

            List<KomodoCafeContent> testList = repo.GetAllContent();
            bool directoryHasContent = testList.Contains(testContent);
            Assert.IsTrue(directoryHasContent);
        }
        private KomodoCafeContent _content;
        private KomodoCafeRepo _kcrepo;
        [TestInitialize]
        public void Arrange()
        {
            _kcrepo = new KomodoCafeRepo();
            _content = new KomodoCafeContent(9, "Derp", "Derpina", IngredientList.Mayonaise, 10.10m);
            _kcrepo.AddContentToDirectory(_content);

            //Stopped here because I remembered we only needed to test our methods for challenge one.
        }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            KomodoCafeContent toBeDeleted = _kcrepo.GetContentByTitle("Derp");

            bool removeResult = _kcrepo.DeleteExistingContent(toBeDeleted);
            Assert.IsTrue(removeResult);
        }
    }
}
