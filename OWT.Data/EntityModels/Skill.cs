using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWT.Data.EntityModels
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public virtual ICollection<ContactSkill> ContactSkill { get; set; }
    }
}
