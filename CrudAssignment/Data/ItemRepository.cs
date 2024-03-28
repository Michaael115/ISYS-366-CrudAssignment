using CrudAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAssignment.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly CrudAssignmentContext _context;

        public ItemRepository(CrudAssignmentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _context.Item.ToListAsync();
        }


        public async Task<bool> UpdateItemAsync()
        {
            return await _context.Item.AnyAsync();
        }
      
        

        public async void DeleteItemAsync(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return;
            }
            _context.Item.Remove(item);
        }

        public Item GetItemById(int id) { 
            return _context.Item.FirstOrDefault(x => x.Id == id);
        }

        public async void AddItemAsync(Item item)
        {
            _context.Item.Add(item);
        }


        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }

        public Task<IEnumerable<Item>> GetItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAysnc(Item item)
        {
            throw new NotImplementedException();
        }

        Task<IList<Item>> IItemRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Item> IItemRepository.GetItemAsync(int? id)
        {
            throw new NotImplementedException();
        }

        Task<Item> IItemRepository.DeleteItem(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
