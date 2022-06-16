using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT.Data.EntityModels
{
    public class ContactSkill
    {
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}
