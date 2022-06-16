using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OWT.Domain.Interfaces;
using OWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT.Data.Manager
{

    public class SkillManager : ISkillManager
    {

        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public SkillManager(DatabaseContext databaseContext, IMapper mapper, IMemoryCache memoryCache)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public async Task<List<SkillModel>> GetAllSkills() 
        {
            return await _databaseContext.Skill.Select(skill => _mapper.Map<SkillModel>(skill)).ToListAsync();
        }

        public async Task<List<SkillModel>> GetAllSkillsWithContacts()
        {
            var skills = await _databaseContext.Skill.Include(c => c.ContactSkill).ThenInclude(s => s.Contact).ToListAsync();
            return _mapper.Map<List<SkillModel>>(skills);
        }
    }
}



