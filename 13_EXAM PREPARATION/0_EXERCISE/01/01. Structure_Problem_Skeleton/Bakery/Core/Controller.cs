using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Bakery.Models.Tables.Contracts;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink;
            if (type.ToLower() == "tea")
            {
                drink = new Tea(name, portion, brand);
                drinks.Add(drink);
            }
            else if (type.ToLower() == "water")
            {
                drink = new Water(name, portion, brand);
                drinks.Add(drink);
            }
            return $"Added {name} ({brand}) to the drink menu";

        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food;
            if (type.ToLower() == "bread")
            {
                food = new Bread(name, price);
                bakedFoods.Add(new Bread(name, price));
            }
            else if (type.ToLower() == "cake")
            {
                food = new Cake(name, price);
                bakedFoods.Add(food);
            }
            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table;
            if (type.ToLower() == "insidetable")
            {
                table = new InsideTable(tableNumber, capacity);
                tables.Add(table);
            }
            else if (type.ToLower() == "outsidetable")
            {
                table = new OutsideTable(tableNumber, capacity);
                tables.Add(table);
            }
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            string result = string.Empty;
            List<ITable> freeTables = tables.Where(t => !t.IsReserved).ToList();
            foreach (Table table in freeTables)
            {
                result += table.GetFreeTableInfo() + Environment.NewLine;
            }
            return result.Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            table.Clear();
            totalIncome += bill;
            return $"Table: {tableNumber}" + Environment.NewLine +
                   $"Bill: {bill:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
