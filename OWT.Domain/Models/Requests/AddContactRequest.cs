using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OWT.Domain.Models.Requests
{
    public class AddContactRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public List<SkillModel> Skills { get; set; }
    }
}
