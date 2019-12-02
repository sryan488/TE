using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListAPI.Services;
using ShoppingListAPI.Models;

namespace ShoppingListAPI.Models
{
    [Route("api/groceries")]
    [ApiController]
    public class GroceriesController : ControllerBase
    {
        private DataAccessObject dao;

        public GroceriesController(DataAccessObject dao)
        {
            this.dao = dao;
        }

        [HttpGet]
        public ActionResult<List<Item>> GetAll()
        {
            List<Item> items = dao.GetAll();

            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetItemById")]
        public ActionResult<Item> GetItemById(int id)
        {
            Item item = dao.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Item item = dao.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            dao.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Item> CreateNewItem([FromBody]Item newItem)
        {
            dao.Add(newItem);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody]Item newItem)
        {
            Item existingItem = dao.Get(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = newItem.Name;
            existingItem.Completed = newItem.Completed;


            //Save existing review back
            dao.Update(existingItem);

            return NoContent();
        }
    }
}