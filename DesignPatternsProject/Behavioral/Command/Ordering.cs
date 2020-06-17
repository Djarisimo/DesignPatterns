using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Behavioral.Command
{
    //Command Design Pattern

    // The Invoker class
    public class Customer
    {
        private OrderCommand _orderCommand;
        private MenuItem _menuItem;
        private FastFoodOrder _order;

        public Customer()
        {
            _order = new FastFoodOrder();
        }

        public void SetCommand(int commandOption)
        {
            _orderCommand = new CommandFactory().GetCommand(commandOption);
        }

        public void SetMenuItem(MenuItem item)
        {
            _menuItem = item;
        }

        public void ExecuteCommand()
        {
            _order.ExecuteCommand(_orderCommand, _menuItem);
        }

        public void ShowCurrentOrder()
        {
            _order.ShowCurrentItems();
        }
    }


    // The Receiver
    public class FastFoodOrder
    {
        public List<MenuItem> currentItems { get; set; }
        public FastFoodOrder()
        {
            currentItems = new List<MenuItem>();
        }

        public void ExecuteCommand(OrderCommand command, MenuItem item)
        {
            command.Execute(this.currentItems, item);
        }

        public void ShowCurrentItems()
        {
            foreach (var item in currentItems)
            {
                item.Display();
            }
            Console.WriteLine("-----------------------");
        }

    }


    // Represents an item being ordered from this restaurant.
    public class MenuItem
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public MenuItem(string name, int amount, double price)
        {
            Name = name;
            Amount = amount;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine("\nName: " + Name);
            Console.WriteLine("Amount: " + Amount.ToString());
            Console.WriteLine("Price: $" + Price.ToString());
        }
    }


    // The Command abstract class
     public abstract class OrderCommand
    {
        public abstract void Execute(List<MenuItem> order, MenuItem newItem);
    }


    // A concrete command
    public class AddCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
        {
            currentItems.Add(newItem);
        }
    }


    // A concrete command
    public class RemoveCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
        {
            currentItems.Remove(currentItems.Where(x => x.Name == newItem.Name).First());
        }
    }


    // A concrete command
    public class ModifyCommand : OrderCommand
    {
        public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
        {
            var item = currentItems.Where(x => x.Name == newItem.Name).First();
            item.Price = newItem.Price;
            item.Amount = newItem.Amount;
        }
    }

    public class CommandFactory
    {
        //Factory method
        public OrderCommand GetCommand(int commandOption)
        {
            switch (commandOption)
            {
                case 1:
                    return new AddCommand();
                case 2:
                    return new ModifyCommand();
                case 3:
                    return new RemoveCommand();
                default:
                    return new AddCommand();
            }
        }
    }
}
