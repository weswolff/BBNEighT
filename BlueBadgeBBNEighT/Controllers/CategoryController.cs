﻿using BBNeighT.Services;
using BBNEighT.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadgeBBNEighT.Controllers
{
    public class CategoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }
        private CategoryService CreateCategoryService()
        {
            var userId = User.Identity.GetUserId();
            var categoryService = new CategoryService(userId);
            return categoryService;
        }
        public IHttpActionResult Get(int id)
        {
            CategoryService categoryService = CreateCategoryService();
            var note = categoryService.GetCategoryById(id);
            return Ok(note);
        }
        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();

            if (!service.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }
    }
}

