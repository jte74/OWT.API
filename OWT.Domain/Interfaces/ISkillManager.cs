using OWT.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT.Domain.Interfaces
{
    public interface ISkillManager
    {
        Task<List<SkillModel>> GetAllSkills();
        Task<List<SkillModel>> GetAllSkillsWithContacts();
    }
}
