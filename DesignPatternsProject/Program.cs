using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsProject.Creational.Builder;
using DesignPatternsProject.Structural.Facade;
using DesignPatternsProject.Behavioral.Command;


namespace DesignPatternsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BuilderExample();
            Console.WriteLine();
            CommandExample();
            Console.WriteLine();
            FacadeExample();
        }

      
        public static void BuilderExample()
        {
            SandwichBuilder builder;

            // Create shop with sandwich assembly line
            AssemblyLine shop = new AssemblyLine();

            // Construct and display sandwiches
            builder = new HamAndCheese();
            shop.Assemble(builder);
            builder.Sandwich.Show();

            builder = new BLT();
            shop.Assemble(builder);
            builder.Sandwich.Show();

            builder = new TurkeyClub();
            shop.Assemble(builder);
            builder.Sandwich.Show();

            // Wait for user
            Console.ReadKey();
        }

        public static void CommandExample()
        {
            Customer customer = new Customer();
            customer.SetCommand(1 /*Add*/);
            customer.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
            customer.ExecuteCommand();

            customer.SetCommand(1 /*Add*/);
            customer.SetMenuItem(new MenuItem("Hamburger", 2, 2.59));
            customer.ExecuteCommand();

            customer.SetCommand(1 /*Add*/);
            customer.SetMenuItem(new MenuItem("Drink", 2, 1.19));
            customer.ExecuteCommand();

            customer.ShowCurrentOrder();

            //Remove the french fries
            customer.SetCommand(3 /*Add*/);
            customer.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
            customer.ExecuteCommand();

            customer.ShowCurrentOrder();

            //Now we want 4 hamburgers rather than 2
            customer.SetCommand(2 /*Add*/);
            customer.SetMenuItem(new MenuItem("Hamburger", 4, 2.59));
            customer.ExecuteCommand();

            customer.ShowCurrentOrder();

            Console.ReadKey();
        }

        public static void FacadeExample()
        {
            Server server = new Server();

            Console.WriteLine("Hello!  I'll be your server today. What is your name?");
            var name = Console.ReadLine();

            Patron patron = new Patron(name);

            Console.WriteLine("Hello " + patron.Name + ". What appetizer would you like? (1-15):");
            var appID = int.Parse(Console.ReadLine());

            Console.WriteLine("That's a good one.  What entree would you like? (1-20):");
            var entreeID = int.Parse(Console.ReadLine());

            Console.WriteLine("A great choice!  Finally, what drink would you like? (1-60):");
            var drinkID = int.Parse(Console.ReadLine());

            Console.WriteLine("I'll get that order in right away.");

            server.PlaceOrder(patron, appID, entreeID, drinkID);

            Console.ReadKey();
        }
    }
}
