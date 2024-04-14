using CrudAssignment.Data;
using CrudAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMem
{
    public class ItemRepositoryMem : IItemRepository
    {
        IList<Item> _list;

        // constructor
        // init our list with our starting items
        public ItemRepositoryMem()
        {
            _list = new List<Item>
        {
            new Item { Id = 1, Name = "Item 1",
            Description = "Description 1", Price = 1.99m },

            new Item { Id = 2, Name = "Item 2",
            Description = "Description 2", Price = 2.99m },

            new Item { Id = 3, Name = "Item 3",
            Description = "Description 3", Price = 3.99m },

            new Item { Id = 4, Name = "Item 4",
            Description = "Description 4", Price = 4.99m },

            new Item { Id = 5, Name = "Item 5",
            Description = "Description 5", Price = 5.99m }
        };
        }
        public Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return Task.FromResult(_list.AsEnumerable());
        }

        public Task<IEnumerable<Item>> GetAllItemsAsync(string? searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return GetAllItemsAsync();
            return Task.FromResult(_list.Where(i => i.Name.Contains(searchString)));
        }

        public Item? GetById(int id)
        {
            return _list.FirstOrDefault(i => i.Id == id);
        }

        public void AddItem(Item item)
        {
            // ID PROBLEM
            // the database took care of creating new unique ids for us
            // that isn't happening anymore and we will need to do it ourselves
            // so you will have to generate and set a new id that will be
            // unique in the list before adding it
            item.Id = _list.Max(x => x.Id) + 1;

            _list.Add(item);
        }

        public void DeleteItem(int id)
        {
            // find the item
            // return if you can not
            var item = _list.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return;
            // we found item so delete it            		    
            _list.Remove(item);
        }

        public Item? GetItem(int id)
        {
            return _list.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateItem(Item item)
        {
            // find the item
            // return false if you can not
            var existingItem = _list.FirstOrDefault(x => x.Id == item.Id);
            if (existingItem == null)
                return false;

            // we found existing item       
            // existingItem is a reference type
            // so making changes to it here WILL change it in the list as well
            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.Price = item.Price;
            return true;
        }

        public IEnumerable<Item> GetAllItems(string? filter)
        {
            throw new NotImplementedException();
        }
    }
}

