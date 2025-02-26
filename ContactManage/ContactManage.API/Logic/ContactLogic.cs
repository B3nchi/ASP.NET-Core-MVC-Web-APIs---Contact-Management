using ContactManage.API.Data;
using ContactManage.API.DTOs;
using ContactManage.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManage.API.Logic
{
    public class ContactLogic
    {
        private readonly AppDbContext _context;

        public ContactLogic(AppDbContext context)
        {
            _context = context;
        }

        // Get list of contacts
        public async Task<List<ContactDto>> GetContactsAsync()
        {
            var contacts = await _context.Contacts.Where(c => !c.IsDeleted).ToListAsync();
            return contacts.Select(ContactToDto).ToList();
        }

        // Get specific contact
        public async Task<ContactDto?> GetContactByIdAsync(Guid id)
        {
            if (id == Guid.Empty) return null;

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null || contact.IsDeleted) return null;

            return ContactToDto(contact);
        }

        // Create a new contact
        public async Task<ContactDto> CreateContactAsync(ContactDto contactDto)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = contactDto.Name,
                Email = contactDto.Email,
                PhoneNumber = contactDto.PhoneNumber,
                Address = contactDto.Address
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return ContactToDto(contact);
        }

        // Update an existing contact
        public async Task<ContactDto?> UpdateContactAsync(Guid id, ContactDto contactDto)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null || contact.IsDeleted)
            {
                return null;
            }

            contact.Name = contactDto.Name;
            contact.Email = contactDto.Email;
            contact.PhoneNumber = contactDto.PhoneNumber;
            contact.Address = contactDto.Address;

            await _context.SaveChangesAsync();
            return ContactToDto(contact);
        }

        // Soft delete a contact
        public async Task<bool> DeleteContactAsync(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null || contact.IsDeleted)
            {
                return false;
            }

            contact.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        // Search contacts by name, email, phone, or address
        public async Task<List<ContactDto>> SearchContactsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetContactsAsync();
            }

            var results = await _context.Contacts
                .Where(c => !c.IsDeleted &&
                            (c.Name.Contains(searchTerm) ||
                             c.Email.Contains(searchTerm) ||
                             c.PhoneNumber.Contains(searchTerm) ||
                             c.Address.Contains(searchTerm)))
                .ToListAsync();

            return results.Select(ContactToDto).ToList();
        }

        // Mapping function from Contact to ContactDto
        private static ContactDto ContactToDto(Contact contact)
        {
            return new ContactDto
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Address = contact.Address
            };
        }
    }
}
