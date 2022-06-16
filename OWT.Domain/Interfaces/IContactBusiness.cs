using OWT.Domain.Models;
using OWT.Domain.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OWT.Domain.Interfaces
{
    public interface IContactBusiness
    {
        Task<List<ContactModel>> GetAllContacts(); 
        Task<List<ContactModel>> GetAllContactsWithSkills(); 
        Task<ContactModel> AddContact(AddContactRequest addContactRequest);
        Task<ContactModel> AddContactWithSkills(AddContactRequest addContactRequest);
        Task<ContactModel> UpdateContact(UpdateContactRequest request);
        Task<ContactModel> GetContact(int id);
        Task<ContactModel> GetContactWithSkills(int id);
        Task RemoveContact(int id);
    }
}
