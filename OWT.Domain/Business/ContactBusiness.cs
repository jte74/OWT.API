using AutoMapper;
using OWT.Domain.Interfaces;
using OWT.Domain.Models;
using OWT.Domain.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OWT.Domain.Business
{
    public class ContactBusiness : IContactBusiness
    {
        public IContactManager _contactManager;
        private readonly IMapper _mapper;
        public ContactBusiness(IContactManager contactManager, IMapper mapper)
        {
            _contactManager = contactManager;
            _mapper = mapper;
        }

        public async Task<List<ContactModel>> GetAllContacts()
        {
            return await _contactManager.GetAllContacts();
        }

        public async Task<List<ContactModel>> GetAllContactsWithSkills()
        {
            return await _contactManager.GetAllContactsWithSkills();
        }

        public async Task<ContactModel> AddContact(AddContactRequest addContactRequest)
        {
            return await _contactManager.AddContact(_mapper.Map<ContactModel>(addContactRequest));
        }
        public async Task<ContactModel> AddContactWithSkills(AddContactRequest addContactRequest)
        {
            return await _contactManager.AddContactWithSkills(_mapper.Map<ContactModel>(addContactRequest));
        }

        public async Task<ContactModel> UpdateContact(UpdateContactRequest request)
        {
            return await _contactManager.UpdateContact(_mapper.Map<ContactModel>(request));
        }

        public async Task<ContactModel> GetContact(int id)
        {
            return await _contactManager.GetContact(id);
        }

        public async Task<ContactModel> GetContactWithSkills(int id)
        {
            return await _contactManager.GetContactWithSkills(id);
        }
        
        public async Task RemoveContact(int id)
        {
           await _contactManager.RemoveContact(id);
        }
    }
}
