using System;

namespace GoldBadge01_ClassLibrary
{
    public enum IngredientList
    {
        Lettuce,
        Mayonaise,
        Tomato,
        Onion,
        Cheese,
        Patty
    }

    public class KomodoCafeContent
    {
        //  Komodo cafe is getting a new menu.The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.
        //  A meal number, so customers can say "I'll have the #5"
        //  A meal name
        //  A description
        //  A list of ingredients,
        //  A price

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public IngredientList Ingredient { get; set; }
        public decimal Price { get; set; }
        public KomodoCafeContent() { }
        public KomodoCafeContent(int mealNumber, string mealName, string description, IngredientList ingredient, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredient = ingredient;
            Price = price;
        }
    }
}
