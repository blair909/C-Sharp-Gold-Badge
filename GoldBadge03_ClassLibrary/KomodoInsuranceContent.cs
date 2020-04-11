using System;
using System.Collections.Generic;

namespace GoldBadge03_ClassLibrary
{
    public class KomodoInsuranceContent
    {
        //  Properties:
        //  BadgeID
        //  List of door names for access
        public int BadgeID { get; set; }
        public string ListOfDoorNames { get; set; }
        public KomodoInsuranceContent() { }
        public KomodoInsuranceContent(int badgeID, string listOfDoorNames)
        {
            BadgeID = badgeID;
            ListOfDoorNames = listOfDoorNames;
        }
    }
}