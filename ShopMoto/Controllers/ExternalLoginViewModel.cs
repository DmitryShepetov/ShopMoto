using System;
using System.ComponentModel.DataAnnotations;

namespace ShopMoto.Controllers
{
    public class ExternalLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string returnUrl { get; set; }
    }
}
