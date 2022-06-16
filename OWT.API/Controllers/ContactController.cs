using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OWT.Domain.Interfaces;
using OWT.Domain.Models.Requests;
using System.Threading.Tasks;

namespace OWT.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ApiControllerBase
    {
        private static IContactBusiness _contactBusiness;
        private readonly IMemoryCache _memoryCache;
        public ContactController(IContactBusiness contactBusiness, IMapper mapper, IMemoryCache memoryCache) : base(mapper)
        {
            _contactBusiness = contactBusiness;
            _memoryCache = memoryCache;
        }

        [HttpGet("contacts")]
        public async Task<ActionResult> GetAllContacts()
        {
            var result = await _contactBusiness.GetAllContacts();
            return Ok(result);
        }

        [HttpGet("contacts-skills")]
        public async Task<ActionResult> GetAllContactsWithSkills()
        {
            var result = await _contactBusiness.GetAllContactsWithSkills();
            return Ok(result);
        }

        [HttpGet("contact")]
        public async Task<ActionResult> GetContact(int id)
        {
            var response = await _contactBusiness.GetContact(id);
            return Ok(response);
        }

        [HttpGet("contact-skills")]
        public async Task<ActionResult> GetContactWithSkills(int id)
        {
            var response = await _contactBusiness.GetContactWithSkills(id);
            return Ok(response);
        }


        [HttpPost("add/contact")]
        public async Task<ActionResult> AddContact(AddContactRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _contactBusiness.AddContact(request);
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("add/contact-skills")]
        public async Task<ActionResult> AddContactWithSkills(AddContactRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _contactBusiness.AddContactWithSkills(request);
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("delete/contact")]
        public async Task<ActionResult> RemoveContact(int id)
        {
          await _contactBusiness.RemoveContact(id);
          return Ok();
        }

        [Authorize(Roles = "Julien")]
        [HttpPost("update")]
        public async Task<ActionResult> UpdateContact(UpdateContactRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _contactBusiness.UpdateContact(request);
                return Ok(response);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
