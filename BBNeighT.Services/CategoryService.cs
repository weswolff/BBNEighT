using BBNEighT.Data;
using BBNEighT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNeighT.Services
{
    public class CategoryService
    {
        private readonly Guid _userID;

        public CategoryService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    //OwnerID = _userID,
                    CategoryID = model.CategoryID,
                    CategoryName = model.CategoryName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        //.Where(e => e. == _userID)
                        .Select(
                            e =>
                                new CategoryListItem
                                {
                                    CategoryName = e.CategoryName,
                                    CategoryID = e.CategoryID,
                                }
                        );

                return query.ToArray();
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryID == id /*&& e.OwnerID == _userID*/);
                return
                    new CategoryDetail
                    {
                        CategoryID = entity.CategoryID,
                        CategoryName = entity.CategoryName,
                    };
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryID == model.CategoryID/* && e.OwnerID == _userID*/);

                entity.CategoryName = model.CategoryName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryID == categoryId/* && e.OwnerID == _userID*/);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
