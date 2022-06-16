using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OWT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OWT.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SkillController : ApiControllerBase
    {
        private static ISkillBusiness _skillBusiness;
        private readonly IMemoryCache _memoryCache;
        public SkillController(ISkillBusiness skillBusiness, IMapper mapper, IMemoryCache memoryCache) : base(mapper)
        {
            _skillBusiness = skillBusiness;
            _memoryCache = memoryCache;
        }

        [HttpGet("skills")]
        public async Task<ActionResult> GetAllContacts()
        {
            var result = await _skillBusiness.GetAllSkills();
            return Ok(result);
        }


        [HttpGet("skills-contacts")]
        public async Task<ActionResult> GetAllContactsWithSkills()
        {
            var result = await _skillBusiness.GetAllSkillsWithContacts();
            return Ok(result);
        }
    }
}





