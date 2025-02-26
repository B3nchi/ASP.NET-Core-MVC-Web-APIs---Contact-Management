using ContactManage.API.DTOs;
using ContactManage.API.Logic;
using ContactManage.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactManage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactLogic _contactLogic;

        public ContactController(ContactLogic contactLogic)
        {
            _contactLogic = contactLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _contactLogic.GetContactsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(Guid id)
        {
            var contact = await _contactLogic.GetContactByIdAsync(id);
            if (contact == null)
            {
                return BadRequest();
            }
            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(ContactDto contact)
        {
            var newContact = await _contactLogic.CreateContactAsync(contact);
            return Ok(newContact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(Guid id, ContactDto updateContact)
        {
            var updatedContact = await _contactLogic.UpdateContactAsync(id, updateContact);
            if (updatedContact == null)
            {
                return BadRequest();
            }
            return Ok(updatedContact);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            var deletedContact = await _contactLogic.DeleteContactAsync(id);
            if (deletedContact == false)
            {
                return NotFound();
            }

            return Ok(deletedContact);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<ContactDto>>> SearchContacts([FromQuery] string searchTerm)
        {
            var results = await _contactLogic.SearchContactsAsync(searchTerm);
            if (results == null || results.Count == 0) return NotFound("No contacts found.");
            return Ok(results);
        }
    }
}
