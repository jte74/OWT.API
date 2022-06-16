
using System.ComponentModel.DataAnnotations;

namespace OWT.Domain.Models.Requests.Auth
{
    public class ConnectUserRequest
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Firstname { get; set; }
    }
}
