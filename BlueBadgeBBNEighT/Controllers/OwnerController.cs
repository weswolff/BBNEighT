using BBNeighT.Services.Owner;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeBBNEighT.Controllers
{
    [Authorize]
    public class OwnerController : ApiController
    {
        private OwnerService CreateOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ownerService = new OwnerService(userId);
            return ownerService;
        }

        public IHttpActionResult GetAllOwners()
        {
            OwnerService ownerService = CreateOwnerService();
            var owners = ownerService.GetOwners();
            return Ok(owners);
        }

        public IHttpActionResult GetOwner(Guid id)
        {
            OwnerService ownerService = CreateOwnerService();
            var owner = ownerService.GetOwnerById(id);
            return Ok(owner);

        }

        public IHttpActionResult DeleteOwner(Guid ownerId)
        {
            var service = CreateOwnerService();

            if (!service.DeleteOwner(ownerId))
                return InternalServerError();
            return Ok();
        }




        //POST USES OWNER CREATE Which we did not create since we are using ApplicationUser
        // public IHttpActionResult Post(OwnerCreate owner)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //     var service CreateOwnerService();
        //         return InternalServerError();
        //    return Ok();
        // }


    }
}
