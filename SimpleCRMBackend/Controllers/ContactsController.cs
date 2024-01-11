using Microsoft.AspNetCore.Mvc;
using SimpleCRMBackend.Models;
using SimpleCRMBackend.Data;
using System.Linq;

namespace SimpleCRMBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // GET: api/Contacts
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(Database.Contacts);
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = Database.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // POST: api/Contacts
        [HttpPost]
        public IActionResult PostContact(Contact contact)
        {
            contact.Id = Database.Contacts.Any() ? Database.Contacts.Max(c => c.Id) + 1 : 1;
            Database.Contacts.Add(contact);
            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public IActionResult PutContact(int id, Contact contact)
        {
            var index = Database.Contacts.FindIndex(c => c.Id == id);
            if (index == -1)
                return NotFound();

            contact.Id = id; // Ensure the ID is not changed
            Database.Contacts[index] = contact;
            return NoContent();
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = Database.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
                return NotFound();

            Database.Contacts.Remove(contact);
            return NoContent();
        }
    }
}