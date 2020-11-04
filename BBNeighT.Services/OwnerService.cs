using BBNEighT.Data;
using BBNEighT.Models.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNeighT.Services.Owner
{
    public class OwnerService
    {
        private readonly String _userId; 

        public OwnerService(String userId)
        {
            _userId = userId;
        }

        //CRUD  
        //CREATE is handled by ApplicationUser (asp.net)

        //READ: GetOwners
        public IEnumerable<OwnerListItem> GetOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                       .Users
                       .Where(e => e.Id == _userId)
                       .Select(
                            e =>
                                new OwnerListItem
                                {
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    DateCreated = e.DateCreated
                                }
                      );
                return query.ToArray();

            }
        }

        //Read: GetOwnerById
        public OwnerDetail GetOwnerById(string id)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var entity=
                    ctx
                        .Users
                        .Single(e => e.Id == _userId);
                return
                new OwnerDetail
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    DateCreated = entity.DateCreated,
                 };
                                     
            }
        }



    }
}
