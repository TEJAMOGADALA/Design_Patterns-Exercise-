using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns

{
    internal class Program
    {
        class Meals
        {
            private string mealType;
            private Dictionary<string, string> parts = new Dictionary<string, string>();
            public Meals(string mealType)
            {
                this.mealType = mealType;
            }

            public string this[string key]
            {
                get { return parts[key]; }
                set { parts[key] = value; }
            }

            public void Display()
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Meal type: {0}", mealType);
                Console.WriteLine("Burger : {0} ", parts["burger"]);
                Console.WriteLine("Shakes : {0} ", parts["shakes"]);
                Console.WriteLine("Deserts : {0} ", parts["deserts"]);
                Console.WriteLine("Toys : {0} ", parts["toys"]);
            }
        }
        abstract class MealBuilder
        {
            protected Meals meal;

            public Meals Meals { get { return meal; } }

            //Abstract build methods
            public abstract void MakeBurger();
            public abstract void MakeShakes();
            public abstract void MakeDeserts();
            public abstract void BuildToys();
        }

        class KidsMealBuilder : MealBuilder
        {
            public KidsMealBuilder()
            {
                meal = new Meals("Kids Meals");
            }

            public override void MakeBurger()
            {
                meal["burger"] = "Ham Burger";
            }

            public override void MakeShakes()
            {
                meal["shakes"] = "Milk Shake";
            }

            public override void MakeDeserts()
            {
                meal["deserts"] = "Donuts";
            }

            public override void BuildToys()
            {
                meal["toys"] = "Car";
            }
        }

        class ValuePackBuilder : MealBuilder
        {
            public ValuePackBuilder()
            {
                meal = new Meals("Value Pack");
            }

            public override void MakeBurger()
            {
                meal["burger"] = "Chicken Burger";
            }

            public override void MakeShakes()
            {
                meal["shakes"] = "Vanilla Shake";
            }

            public override void MakeDeserts()
            {
                meal["deserts"] = "Dark Fantacy";
            }

            public override void BuildToys()
            {
                meal["toys"] = "Bus";
            }
        }

        class AllinOneBuilder : MealBuilder
        {
            public AllinOneBuilder()
            {
                meal = new Meals("All in one Pack");
            }

            public override void MakeBurger()
            {
                meal["burger"] = "Ham and Chicken Burger";
            }

            public override void MakeShakes()
            {
                meal["shakes"] = "Milk Shake and Strawberry Shake";
            }

            public override void MakeDeserts()
            {
                meal["deserts"] = "Chocos and brownies";
            }

            public override void BuildToys()
            {
                meal["toys"] = "Car and Bus";
            }
        }

        class Order
        {
            public void Construct(MealBuilder mealBuilder)
            {
                mealBuilder.MakeBurger();
                mealBuilder.MakeShakes();
                mealBuilder.MakeDeserts();
                mealBuilder.BuildToys();
            }
        }
        static void Main(string[] args)
        {
            MealBuilder builder;

            Order order = new Order();

            builder = new KidsMealBuilder();
            order.Construct(builder);
            builder.Meals.Display();

            builder = new ValuePackBuilder();
            order.Construct(builder);
            builder.Meals.Display();

            builder = new AllinOneBuilder();
            order.Construct(builder);
            builder.Meals.Display();

            Console.ReadKey();
        }
    }
}