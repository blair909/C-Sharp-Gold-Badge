using System;
using System.Collections.Generic;
using System.Text;

namespace GoldBadge01_ClassLibrary
{
    public class KomodoCafeRepo
    {
        //  Komodo cafe is getting a new menu.The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.
        //  A meal number, so customers can say "I'll have the #5"
        //  A meal name
        //  A description
        //  A list of ingredients,
        //  A price

        protected readonly List<KomodoCafeContent> _contentDirectory = new List<KomodoCafeContent>();

        public bool AddContentToDirectory(KomodoCafeContent content)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<KomodoCafeContent> GetAllContent()
        {
            return _contentDirectory;
        }
        public bool DeleteExistingContent(KomodoCafeContent komodoCafeContent)
        {
            bool deleteResult = _contentDirectory.Remove(komodoCafeContent);
            return deleteResult;
        }
        public KomodoCafeContent GetContentByTitle(string title)
        {
            foreach (KomodoCafeContent content in _contentDirectory)
            {
                if (content.MealName.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
    }
}
