using GoldBadge02_ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge02ConsoleApp
{
    public class KomodoClaimsProgramUI
    {
        private readonly KomodoClaimsRepo _kcRepo = new KomodoClaimsRepo();
        public void Run()
        {
            SeedContentQueue();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select then press enter: \n" +
                    "1) Create a new claim \n" +
                    "2) Take care of claims \n" +
                    "3) Show all claims \n" +
                    "4) Exit \n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            CreateNewClaim();
                            break;
                        }
                    case "2":
                        {
                            TakeCareOfNextClaim();
                            break;
                        }
                    case "3":
                        {
                            GetAllClaims();
                            break;
                        }
                    case "4":
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
        private void CreateNewClaim()
        {
            Console.Clear();
            KomodoClaimsContent content = new KomodoClaimsContent();

            Console.WriteLine("Please enter a claim ID number (ex: 1, 2, 3, etc...)");
            content.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the claim type as a number: \n" +
                "1) Car \n" +
                "2) Home \n" +
                "3) Theft \n");
            string claimChoice = Console.ReadLine();
            int claimNumber = int.Parse(claimChoice);
            content.TypeOfClaim = (ClaimType)claimNumber;

            Console.WriteLine("Please enter a claim description");
            Console.ReadLine();

            Console.WriteLine("Please enter the claim amount as a decimal (ex: 300.99, 210.75, etc...");
            content.ClaimAmount = decimal.Parse(Console.ReadLine(), NumberStyles.Currency);

            Console.WriteLine("Please enter the date of the incident \n" +
                "Please use format: YYYY,MM,DD \n" +
                "Ex: 0001,01,01");
            string incidentDate = Console.ReadLine();
            content.DateOfIncident = DateTime.Parse(incidentDate);

            Console.WriteLine("Please enter the date the claim was made \n" +
                "Please use format: YYYY,MM,DD \n" +
                "Ex: 0001,01,01");
            string claimDate = Console.ReadLine();
            content.DateOfClaim = DateTime.Parse(claimDate);

            Console.WriteLine("Please enter whether the claim is valid \n" +
                "Enter 'true' if the claim is valid and 'false' if it is not");
            string validityChoice = Console.ReadLine().ToLower();
            switch (validityChoice)
            {
                case "true":
                    {
                        content.IsValid = true;
                        break;
                    }
                case "false":
                    {
                        content.IsValid = false;
                        break;
                    }
            }
            bool added = _kcRepo.AddClaimToDirectory(content);
            if (added)
            {
                Console.WriteLine("Your Content has been added \n" +
                    "Please press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There has been an error, please try again \n" +
                    "Pleas press any key to continue");
                Console.ReadKey();
            }
        }
        private void DisplayContent(KomodoClaimsContent content)
        {
            Console.WriteLine($"Claim ID: {content.ClaimID} \n " +
                $"Type of Claim: {content.TypeOfClaim} \n " +
                $"Description: {content.Description} \n " +
                $"Claim Amount: ${content.ClaimAmount} \n " +
                $"Date of Incident: {content.DateOfIncident} \n " +
                $"Date of Claim: {content.DateOfClaim} \n " +
                $"Is Valid Claim: {content.IsValid} ");
        }
        private void GetAllClaims()
        {
            Console.Clear();
            Queue<KomodoClaimsContent> listofContent = _kcRepo.GetAllClaims();
            foreach (KomodoClaimsContent content in listofContent)
            {
                DisplayContent(content);
            }
            Console.Write("Please press any key to continue");
            Console.ReadKey();
        }
        public void SeedContentQueue()
        {
            KomodoClaimsContent claimAlpha = new KomodoClaimsContent(1, ClaimType.Car, "Car accident on 465 ", 400.00m, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            _kcRepo.AddClaimToDirectory(claimAlpha);
            KomodoClaimsContent claimBeta = new KomodoClaimsContent(2, ClaimType.Car, "Zeus threw lightning at my Subaru! ", 9001.00m, new DateTime(2020, 01, 01), new DateTime(2020, 01, 02), true);
            _kcRepo.AddClaimToDirectory(claimBeta);
            KomodoClaimsContent claimGamma = new KomodoClaimsContent(3, ClaimType.Home, "Hephaestus burned down my house! ", 10.99m, new DateTime(0020, 01, 01), new DateTime(0020, 01, 02), true);
            _kcRepo.AddClaimToDirectory(claimGamma);
            KomodoClaimsContent claimDelta = new KomodoClaimsContent(4, ClaimType.Theft, "Prometheus stole my eternal fire! #eternalsuffering ", 1000000.00m, new DateTime(0001, 01, 01), new DateTime(0001, 01, 02), true);
            _kcRepo.AddClaimToDirectory(claimDelta);
        }
        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            Queue<KomodoClaimsContent> listofContent = _kcRepo.LookAtNextClaim();
            KomodoClaimsContent nextInLine = listofContent.Peek();
            DisplayContent(nextInLine);
            Console.WriteLine("Would you like to deal with this claim now? (yes or no)");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "yes")
            {
                Queue<KomodoClaimsContent> blistofContent = _kcRepo.ProcessNextClaim();
                blistofContent.Dequeue();
                Console.WriteLine("Okay, let's get started");
            }
            else if (userInput == "no")
            {
                Console.WriteLine("Okay, let's return to the main menu");
            }
            else
            {
                Console.WriteLine("Please enter a valid response");
            }
            Console.WriteLine("Please press any key to continue");
            Console.ReadKey();
        }
    }
}