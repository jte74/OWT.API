using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OWT.Data.EntityModels;
using OWT.Domain.Interfaces;
using OWT.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OWT.Data.Manager
{
    public class ContactManager : IContactManager
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        public ContactManager(DatabaseContext databaseContext, IMapper mapper, IMemoryCache memoryCache)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _memoryCache = memoryCache; 
        }

        public async Task<List<ContactModel>> GetAllContacts()
        {
            return await _databaseContext.Contact.Select(contact => _mapper.Map<ContactModel>(contact)).ToListAsync();
        }

        public async Task<List<ContactModel>> GetAllContactsWithSkills()
        {
            var contact = await _databaseContext.Contact.Include(c => c.ContactSkill).ThenInclude(s => s.Skill).ToListAsync();
            return _mapper.Map<List<ContactModel>>(contact);
        }

        public async Task<ContactModel> AddContact(ContactModel contactModel)
        {
            var contact = _mapper.Map<Contact>(contactModel);
            await _databaseContext.AddAsync(contact);
            await _databaseContext.SaveChangesAsync();
            contactModel.Id = contact.Id;

            return contactModel;
        }

        public async Task<ContactModel> AddContactWithSkills(ContactModel contactModel)
        {
            foreach(var item in contactModel.Skills)
            {
                var contactSkill = new EntityModels.ContactSkill()
                {
                    Contact = _mapper.Map<Contact>(contactModel),
                    Skill = _mapper.Map<Skill>(item),
                };

                await _databaseContext.AddAsync(contactSkill);
                await _databaseContext.SaveChangesAsync();
            }
           
            return contactModel;
        }

        public async Task<ContactModel> GetContact(int id)
        {
            var response = await _databaseContext.Contact.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ContactModel>(response);
        }

        public async Task<ContactModel> GetContactWithSkills(int id)
        {
            var contact = await _databaseContext.Contact.Where(x => x.Id == id)
                                                        .Include(c => c.ContactSkill)
                                                        .ThenInclude(s => s.Skill)
                                                        .ToListAsync();

            return _mapper.Map<ContactModel>(contact.FirstOrDefault());
        }

        public async Task RemoveContact(int id)
        {
            Contact contact = new Contact() { Id = id };
            _databaseContext.Contact.Attach(contact);
            _databaseContext.Contact.Remove(contact);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<ContactModel> UpdateContact(ContactModel contactModel)
        {
            var idCache = _memoryCache.Get("Id");

            if (idCache.ToString() != contactModel.Id.ToString())
            {
                return null;
            }
            _databaseContext.Update(_mapper.Map<Contact>(contactModel));
            await _databaseContext.SaveChangesAsync();

            return contactModel;
        }

        public async Task<ContactModel> AuthenticateContact(string mail, string firstname)
        {
            ContactModel result = null;
            var contact = await _databaseContext.Contact.Where(t => t.Email == mail).FirstOrDefaultAsync();

            if (contact != null && contact.FirstName == firstname)
            {
                _memoryCache.Set("Id", contact.Id);

                //To Do: AutoMapper
                result = new ContactModel
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Address = contact.Address,
                    Email = contact.Email,
                    FullName = contact.FullName,
                    Phone = contact.Phone
                };
            }
            return result;

        }
    }
}
