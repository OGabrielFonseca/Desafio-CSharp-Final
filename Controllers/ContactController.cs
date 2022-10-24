using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtividadeAPI.Entities;
using AtividadeAPI.Context;

namespace AtividadeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContactController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create (Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFromId), new { id = contact.Id}, contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetFromId(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
                return NotFound();

            return Ok(contact);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contact contact)
        {
            var contactDataBase = _context.Contacts.Find(id);
            if(contactDataBase == null)
                return NotFound();

            contactDataBase.Name = contact.Name;
            contactDataBase.Number = contact.Number;
            contactDataBase.Active = contact.Active;

            _context.Contacts.Update(contactDataBase);
            _context.SaveChanges();

            return Ok(contactDataBase);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFromId(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
                return NotFound();

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpGet("GetFromName")]
        public IActionResult GetFromName(string name)
        {
            var contact = _context.Contacts.Where(x => x.Name.Contains(name));

            if(contact == null)
                return NotFound();

            return Ok(contact);

        }

    }
}