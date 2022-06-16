using System;
using System.Collections.Generic;

namespace OWT.Domain.Models
{
    public class SkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public List<ContactModel> Contacts { get; set; }
    }
}
