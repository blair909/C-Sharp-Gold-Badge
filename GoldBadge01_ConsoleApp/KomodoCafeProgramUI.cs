using GoldBadge01_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge01_ConsoleApp
{
    public class KomodoCafeProgramUI
    {
        //  Komodo cafe is getting a new menu.The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.
        //  A meal number, so customers can say "I'll have the #5"
        //  A meal name
        //  A description
        //  A list of ingredients, 
        //  A price
        public KomodoCafeRepo _kcRepo = new KomodoCafeRepo();
        public void Run()
        {
            SeedContentList();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd like to select then press enter: \n" +
                    "1) Create new menu items \n" +
                    "2) Delete menu items \n" +
                    "3) Show all menu items \n" +
                    "4) Exit \n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            CreateNewContent();
                            break;
                        }
                    case "2":
                        {
                            DeleteExistingContent();
                            break;
                        }
                    case "3":
                        {
                            GetAllContent();
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
        private void CreateNewContent()
        {
            Console.Clear();
            KomodoCafeContent content = new KomodoCafeContent();

            Console.Write("Please enter a meal number: (ex: 1, 2, 3, etc... ");
            content.MealNumber = int.Parse(Console.ReadLine());

            Console.Write("Please enter a meal name: ");
            content.MealName = Console.ReadLine();

            Console.Write("Please enter a description: ");
            content.Description = Console.ReadLine();

            Console.WriteLine("Please select an ingredient(s): \n" +
                "1) Lettuce \n" +
                "2) Mayonaise \n" +
                "3) Tomato \n" +
                "4) Onion \n" +
                "5) Cheese \n" +
                "6) Patty");

            string ingredientChoice = Console.ReadLine();
            int ingredientID = int.Parse(ingredientChoice);
            content.Ingredient = (IngredientList)ingredientID;

            Console.Write("Please enter a price in dollars: (ex: 4.99, 6.37, 10.34, etc... ");
            content.Price = decimal.Parse(Console.ReadLine());

            bool added = _kcRepo.AddContentToDirectory(content);
            if (added)
            {
                Console.Write("Your items have been added \n" +
                    "Please press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.Write("There has been an error, please try again \n" +
                    "Please press any key to continue");
                Console.ReadKey();
            }
        }
        private void DeleteExistingContent()
        {
            Console.Clear();
            Console.Write("Please choose the item you'd like to remove: \n");
            List<KomodoCafeContent> contentList = _kcRepo.GetAllContent();

            int count = 0;
            foreach (KomodoCafeContent content in contentList)
            {
                count++;
                Console.Write($"{count} - {content.MealName} \n");
            }
            int targetContentID = int.Parse(Console.ReadLine());
            int targetIndex = targetContentID - 1;
            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                KomodoCafeContent desiredContent = contentList[targetIndex];
                if (_kcRepo.DeleteExistingContent(desiredContent))
                {
                    Console.Write($"{desiredContent.MealName} has been removed ");
                }
                else
                {
                    Console.Write("Sorry, but you can't do that ");
                }
            }
            else
            {
                Console.Write("There has been an error, please try again \n" +
                "Please press any key to continue");
                Console.ReadKey();
            }
        }
        private void DisplayContent(KomodoCafeContent content)
        {
            Console.WriteLine($"Meal Number: {content.MealNumber} \n" +
                $"Meal Name: {content.MealName} \n" +
                $"Description: {content.Description} \n" +
                $"Ingredient(s): {content.Ingredient} \n" +
                $"Price: {content.Price}");
        }
        private void GetAllContent()
        {
            Console.Clear();
            List<KomodoCafeContent> listofContent = _kcRepo.GetAllContent();
            foreach (KomodoCafeContent content in listofContent)
            {
                DisplayContent(content);
            }
            Console.Write("Please press any key to continue");
            Console.ReadKey();
        }
        private void SeedContentList()
        {
            //  Meal Number
            //  Meal Name
            //  Description
            //  Ingredient
            //  Price
            KomodoCafeContent dodecaDiabetesBurger = new KomodoCafeContent(1, "Dodeca Diabetes Burger", "Our signature burger will give you diabetes faster than any other!", IngredientList.Patty /*12 Patties */, 19.99m);
            _kcRepo.AddContentToDirectory(dodecaDiabetesBurger);
            KomodoCafeContent justCheese = new KomodoCafeContent(2, "Just Cheese", "Simple, yet elegant.  Our Just Cheese burger just has cheese!", IngredientList.Cheese, 99.99m);
            _kcRepo.AddContentToDirectory(justCheese);
            KomodoCafeContent bltMayo = new KomodoCafeContent(3, "BLT Mayo", "The Burger, Lettuce, Tomato, Mayo is back! But without bacon and a mayonaise infused burger instead!", IngredientList.Lettuce, 1.00m);
            _kcRepo.AddContentToDirectory(bltMayo);
            KomodoCafeContent megaOnion = new KomodoCafeContent(4, "Mega Onion", "You want onions? Oh we'll give you onions! A whole crap ton of them! Can you resist the tears?", IngredientList.Onion, 1050.99m);
            _kcRepo.AddContentToDirectory(megaOnion);
        }
    }
}