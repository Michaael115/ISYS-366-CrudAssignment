using CrudAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using UI.Data;

namespace CrudAssignment.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly CrudAssignmentContext _context;

        public ItemRepository(CrudAssignmentContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetAllItems(string? filter)
        {
            if (string.IsNullOrEmpty(filter))
                return _context.Item.ToList();

            return _context.Item.Where(i => i.Name.Contains(filter)).ToList();
        }

        public Item? GetById(int id)
        {
            return _context.Item.FirstOrDefault(i => i.Id == id);
        }

        public void AddItem(Item item)
        {
            _context.Item.Add(item);

            _context.SaveChanges();
        }

        public bool UpdateItem(Item item)
        {
            _context.Attach(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public void DeleteItem(int id)
        {
            var item = _context.Item.Find(id);
            if (item == null)
            {
                return;
            }

            _context.Item.Remove(item);

            _context.SaveChanges();
        }


    }
}
