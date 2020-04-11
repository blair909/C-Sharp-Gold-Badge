using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace GoldBadge03_ClassLibrary
{
    public class KomodoInsuranceRepo
    {
        protected readonly List<KomodoInsuranceContent> _content = new List<KomodoInsuranceContent>();
        protected readonly Dictionary<KomodoInsuranceContent, KomodoInsuranceContent> dictionary = new Dictionary<KomodoInsuranceContent, KomodoInsuranceContent>();

        //  Methods that do the following:
        //  Create a dictionary of badges
        //  The key for the dictionary will be the BadgeID
        //  The value for the dictionary will be the List of Door Names

        //  Program that does the following:
        //  Create a new badge
        //  Update doors on an existing badge
        //  Delete all doors from an existing badge
        //  Show a list with all badge numbers and door access

        public bool CreateNewBadge(KomodoInsuranceContent content)
        {
            int startingCount = _content.Count;
            _content.Add(content);
            bool wasAdded = (_content.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public KomodoInsuranceContent GetContentByBadgeID(int badgeID)
        {
            foreach (KomodoInsuranceContent content in _content)
            {
                if (content.BadgeID == badgeID)
                {
                    return content;
                }
            }
            return null;
        }
        public bool AddOrUpdateDictionaryEntry(int originalBadgeID, KomodoInsuranceContent updatedContent)
        {
            KomodoInsuranceContent oldContent = GetContentByBadgeID(originalBadgeID);
            if (oldContent != null)
            {
                oldContent.BadgeID = updatedContent.BadgeID;
                oldContent.ListOfDoorNames = updatedContent.ListOfDoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteExistingBadgeValue(KomodoInsuranceContent listOfDoorNames)
        {
            bool deleteValue = _content.Remove(listOfDoorNames);
            return deleteValue;
        }
        public List<KomodoInsuranceContent> GetAllKeysAndValues()
        {
            return _content;
        }
    }
}