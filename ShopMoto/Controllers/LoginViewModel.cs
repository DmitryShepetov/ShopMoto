using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Controllers
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string returnUrl { get; set; }
        public IEnumerable<AuthenticationScheme> ExternalProviders { get; set; }
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string Country { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        public bool Gender { get; set; }
    }
}
