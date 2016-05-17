using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using VSTDA_Backend.API.Models;

namespace VSTDA_Backend.API.Controllers
{
    public class TodoesController : ApiController
    {
        private VSTDA_BackendAPIContext db = new VSTDA_BackendAPIContext();

        // GET: api/Todoes
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public IQueryable<Todo> GetTodoes()
        {
            return db.Todoes;
        }

        // GET: api/Todoes/5
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        [ResponseType(typeof(Todo))]
        public async Task<IHttpActionResult> GetTodo(int id)
        {
            Todo todo = await db.Todoes.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // PUT: api/Todoes/5
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTodo(int id, Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todo.TodoId)
            {
                return BadRequest();
            }

            db.Entry(todo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todoes
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        [ResponseType(typeof(Todo))]
        public async Task<IHttpActionResult> PostTodo(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Todoes.Add(todo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = todo.TodoId }, todo);
        }

        // DELETE: api/Todoes/5
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        [ResponseType(typeof(Todo))]
        public async Task<IHttpActionResult> DeleteTodo(int id)
        {
            Todo todo = await db.Todoes.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            db.Todoes.Remove(todo);
            await db.SaveChangesAsync();

            return Ok(todo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoExists(int id)
        {
            return db.Todoes.Count(e => e.TodoId == id) > 0;
        }
    }
}