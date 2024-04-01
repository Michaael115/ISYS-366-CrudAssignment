using CrudAssignment.Models;
namespace CrudAssignment.Data

{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems(string? filter);

        Item? GetById(int id);

        void AddItem(Item item);

        bool UpdateItem(Item item);

        void DeleteItem(int id);
    }
}
