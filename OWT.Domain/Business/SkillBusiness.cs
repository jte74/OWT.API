using AutoMapper;
using OWT.Domain.Interfaces;
using OWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT.Domain.Business
{
    public class SkillBusiness :ISkillBusiness
    {
        public ISkillManager _skillManager;
        private readonly IMapper _mapper;
        public SkillBusiness(ISkillManager skillManager, IMapper mapper)
        {
            _skillManager = skillManager;
            _mapper = mapper;
        }

        public async Task<List<SkillModel>> GetAllSkills()
        {
            return await _skillManager.GetAllSkills();
        }

        public async Task<List<SkillModel>> GetAllSkillsWithContacts()
        {
            return await _skillManager.GetAllSkillsWithContacts();
        }
    }
}
