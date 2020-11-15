using BBNEighT.Data;
using BBNEighT.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNeighT.Services
{
    public class ItemService
    {
        private readonly Guid _userId;

        public ItemService(Guid userId)
        {
            _userId = userId;
        }       
        public bool CreateItem(ItemCreate model)
        {
            var entity =
                new Item()
                {
                    OwnerID = _userId,
                    ItemName = model.ItemName,
                    CategoryID = model.CategoryID,
                    RoomID = model.RoomID,        
                    Description = model.Description,
                    Value = model.Value,
                    AquiredDate = model.AquiredDate,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;        
            }
        }
        public IEnumerable<ItemListItem> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Items
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ItemListItem
                                {
                                    ItemID = e.ItemID,
                                    ItemName = e.ItemName,
                                    CategoryID = e.CategoryID,
                                    Category = e.Category.CategoryName,
                                    RoomID = e.RoomID,
                                    Room =e.Room.RoomName,
                                    Description = e.Description,
                                    Value = e.Value,
                                    AquiredDate = e.AquiredDate,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public ItemDetail GetItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemID == id && e.OwnerID == _userId);
                return
                    new ItemDetail
                    {
                        ItemID = entity.ItemID,
                        ItemName = entity.ItemName,
                        CategoryID = entity.CategoryID,
                        Category = entity.Category.CategoryName,
                        RoomID = entity.RoomID,
                        Room = entity.Room.RoomName,
                        Description = entity.Description,
                        AquiredDate = entity.AquiredDate,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateItem(ItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemID == model.ItemID && e.OwnerID == _userId);
                               
                entity.ItemName = model.ItemName;
                entity.CategoryID = model.CategoryID;
                entity.RoomID = model.RoomID;
                entity.Description = model.Description;
                entity.Value = model.Value;
                entity.AquiredDate = model.AquiredDate;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Items
                        .Single(e => e.ItemID == itemId && e.OwnerID == _userId);

                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
