using AutoMapper;
using OWT.Data.EntityModels;
using OWT.Domain.Models;
using OWT.Domain.Models.Requests;
using System.Linq;

namespace OWT.API.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            //CreateMap<Skill, SkillModel>();
            //CreateMap<SkillModel, Skill>();

            CreateMap<Contact, ContactModel>()
            .ForMember(s => s.Skills, opt => opt.MapFrom(p => p.ContactSkill.Select(x=>x.Skill).ToList())).ReverseMap();

            CreateMap<Skill, SkillModel>()
            .ForMember(s => s.Contacts, opt => opt.MapFrom(p => p.ContactSkill.Select(x => x.Contact).ToList())).ReverseMap();

            CreateMap<AddContactRequest, ContactModel>();
            CreateMap<UpdateContactRequest, ContactModel>();
        }
    }
}
