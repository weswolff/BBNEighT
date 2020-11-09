using BBNEighT.Data;
using BBNEighT.Models.Owner;
using BBNEighT.Models.OwnerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBNeighT.Services.Owner
{
    public class OwnerService
    {
        private readonly Guid  _userId; 

        public OwnerService(Guid userId)
        {
            _userId = userId;
        }

        //CRUD  

        //CREATE is handled by ApplicationUser (asp.net)
        //Coded for possible future use --Not Tested
        /*
            public bool CreateOwner(OwnerCreate model)
            {
                var entity =
                    new Owner()
                    {
                        OwnerId = _userId,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        DateCreated = model.DateCreated
                    };
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Owners.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }*/

        //READ: GetOwners
        public IEnumerable<OwnerListItem> GetOwners()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                       .Users
                       .Select(
                            e =>
                                new OwnerListItem
                                {
                                    Id = e.Id,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    Email = e.Email,
                                    DateCreated = e.DateCreated
                                }
                      ); ; 
                return query.ToArray();

            }
        }

        //Read: GetOwnerById
        public OwnerDetail GetOwnerById(Guid userId)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var entity=
                    ctx
                        .Users
                        .Single(e => e.Id == _userId.ToString());
                return
                new OwnerDetail
                {
                    Id = Guid.Parse(entity.Id),
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    DateCreated = entity.DateCreated,
                 };               
            }
        }

        public bool UpdateOwner(OwnerEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == _userId.ToString());
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;          
            }
        }

        public bool DeleteOwner(Guid Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Users
                        .Single(e => e.Id == _userId.ToString());
                ctx.Users.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }
}
