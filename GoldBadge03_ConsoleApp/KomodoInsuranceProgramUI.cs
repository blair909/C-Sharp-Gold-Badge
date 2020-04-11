using GoldBadge03_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge03_ConsoleApp
{
    class KomodoInsuranceProgramUI
    {
        public KomodoInsuranceRepo _kiRepo = new KomodoInsuranceRepo();
        public void Run()
        {
            SeedBadgeDictionary();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please enter the number of the option you'd like to select then press enter: \n" +
                    "1) Create new badge \n" +
                    "2) Add/update existing floor access \n" +
                    "3) Delete existing badge floor access \n" +
                    "4) Show all badges \n" +
                    "5) Exit \n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            CreateNewBadge();
                            break;
                        }
                    case "2":
                        {
                            AddOrUpdateDictionaryEntry();
                            break;
                        }
                    case "3":
                        {
                            DeleteExistingBadgeValue();
                            break;
                        }
                    case "4":
                        {
                            GetAllKeysAndValues();
                            break;
                        }
                    case "5":
                        {
                            continueToRun = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();
            KomodoInsuranceContent content = new KomodoInsuranceContent();

            Console.Write("Please enter a new badge ID (ex: 1, 10, 100, etc...)");
            content.BadgeID = int.Parse(Console.ReadLine());

            Console.Write("Please enter a new door access list (ex: A1, B2, C3, etc...)");
            content.ListOfDoorNames = Console.ReadLine();

            bool added = _kiRepo.CreateNewBadge(content);
            if (added)
            {
                Console.Write("Your badge(s) have been added ");
            }
            else
            {
                Console.Write("There has been an error, please try again ");
            }
            Console.WriteLine("Please press any key to continue");
            Console.ReadKey();
        }
        private void AddOrUpdateDictionaryEntry()
        {
            Console.Clear();
            Console.WriteLine("Please choose the item you'd like to update:");
            List<KomodoInsuranceContent> contentList = new List<KomodoInsuranceContent>();
            int count = 0;
            foreach (KomodoInsuranceContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count} - {content.BadgeID}");
            }
            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                KomodoInsuranceContent desiredContent = contentList[targetIndex];
                if (_kiRepo.AddOrUpdateDictionaryEntry(targetIndex, desiredContent))
                {
                    Console.WriteLine($"Badge ID {desiredContent.BadgeID} has been updated ");
                }
                else
                {
                    Console.WriteLine("Input invalid ");
                }
            }
            else
            {
                Console.WriteLine("No content had that ID ");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        private void DeleteExistingBadgeValue()
        {
            Console.Clear();
            Console.WriteLine("Please choose the item you'd like to update:");
            List<KomodoInsuranceContent> contentList = new List<KomodoInsuranceContent>();
            int count = 0;
            foreach (KomodoInsuranceContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count} - {content.ListOfDoorNames}");
            }
            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                KomodoInsuranceContent desiredContent = contentList[targetIndex];
                if (_kiRepo.DeleteExistingBadgeValue(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.ListOfDoorNames} has been removed ");
                }
                else
                {
                    Console.WriteLine("Input invalid ");
                }
            }
            else
            {
                Console.WriteLine("No content had that ID ");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        private void DisplayContent(KomodoInsuranceContent content)
        {
            Console.WriteLine($"Badge ID: {content.BadgeID} \n" +
                $"List of Door Names: {content.ListOfDoorNames} ");
        }
        private void GetAllKeysAndValues()
        {
            Console.Clear();
            List<KomodoInsuranceContent> keyvalueList = _kiRepo.GetAllKeysAndValues();
            foreach (KomodoInsuranceContent content in keyvalueList)
            {
                DisplayContent(content);
            }
            Console.Write("Please press any key to continue");
            Console.ReadKey();
        }
        private void SeedBadgeDictionary()
        {
            KomodoInsuranceContent alpha = new KomodoInsuranceContent(1, "A1, B1, C1");
            _kiRepo.CreateNewBadge(alpha);
            KomodoInsuranceContent beta = new KomodoInsuranceContent(1, "A2, B2, C2");
            _kiRepo.CreateNewBadge(beta);
            KomodoInsuranceContent gamma = new KomodoInsuranceContent(1, "A3, B3, C3");
            _kiRepo.CreateNewBadge(gamma);
            KomodoInsuranceContent delta = new KomodoInsuranceContent(1, "A4, B4, C4");
            _kiRepo.CreateNewBadge(gamma);
            KomodoInsuranceContent epsilon = new KomodoInsuranceContent(1, "A5, B5, C5");
            _kiRepo.CreateNewBadge(epsilon);
        }
    }
}
