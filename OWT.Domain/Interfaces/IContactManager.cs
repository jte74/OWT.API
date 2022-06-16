using OWT.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OWT.Domain.Interfaces
{
    public interface IContactManager
    {
        Task<List<ContactModel>> GetAllContacts();
        Task<List<ContactModel>> GetAllContactsWithSkills();
        Task<ContactModel> UpdateContact(ContactModel contactModel);
        Task<ContactModel> AddContact(ContactModel contactModel);
        Task<ContactModel> AddContactWithSkills(ContactModel contactModel);
        Task<ContactModel> GetContact(int id);
        Task<ContactModel> GetContactWithSkills(int id);
        Task<ContactModel> AuthenticateContact(string mail, string firstname);
        Task RemoveContact(int id);
    }
}
