using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ShoppingListAPI.Models;

namespace ShoppingListAPI.Services
{
    public class DataAccessObject : IDataAccessObject<Item>
    {

        public List<Item> Groceries { get; set; }

        public DataAccessObject()
        {
            this.Groceries = new List<Item>
            {
                new Item { Id=1,Name="Oatmeal",Completed=false},
                new Item { Id=2,Name="Milk",Completed=false},
                new Item { Id=3,Name="Banana",Completed=false},
                new Item { Id=4,Name="Strawberries",Completed=false},
                new Item { Id=5,Name="Lunch Meat",Completed=false},
                new Item { Id=6,Name="Bread",Completed=false},
                new Item { Id=7,Name="Grapes",Completed=false},
                new Item { Id=8,Name="Steak",Completed=false},
                new Item { Id=9,Name="Salad",Completed=false},
                new Item { Id=10,Name="Cookies",Completed=false}
            };
        }

        public List<Item> GetAll()
        {
            return this.Groceries;
        }

        public Item Get(int id)
        {
            return Groceries.Find(item => item.Id == id);
        }

        public void Add(Item item)
        {
            Groceries.Add(item);
        }

        public void Update(Item item)
        {
            Groceries[Groceries.FindIndex(i => i.Id == item.Id)] = item;
        }

        public void Delete(int id)
        {
            Groceries.Remove(Groceries.Find(item => item.Id == id));
        }

    }
}