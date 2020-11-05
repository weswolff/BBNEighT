using BBNeighT.Services;
using BBNEighT.Models.Item;
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
    public class ItemController : ApiController
    {
        public IHttpActionResult Get()
        {
            ItemService itemService = CreateItemService();
            var items = itemService.GetItems();
            return Ok(items);
        }
        public IHttpActionResult Post(ItemCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateItemService();

            if (!service.CreateItem(item))
                return InternalServerError();

            return Ok();
        }
        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var itemService = new ItemService(userId);
            return itemService;
        }

        public IHttpActionResult Get(int id)
        {
            ItemService itemService = CreateItemService();
            var item = itemService.GetItemById(id);
            return Ok(item);
        }

        public IHttpActionResult Put(ItemEdit item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateItemService();

            if (!service.UpdateItem(item))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateItemService();

            if (!service.DeleteItem(id))
                return InternalServerError();

            return Ok();
        }
       
    }
}
