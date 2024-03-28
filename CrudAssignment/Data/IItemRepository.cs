using CrudAssignment.Models;
namespace CrudAssignment.Data

{
    public interface IItemRepository
    {
        Task<Item> DeleteItem(int? id);
        Task<IList<Item>> GetAllAsync();
        Task<IEnumerable<Item>> GetItemAsync();

        Task<Item> GetItemAsync(int? id);

        Task<bool> UpdateItemAysnc(Item item);
    }
}
