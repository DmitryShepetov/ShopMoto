using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopMoto.Data.Model
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [JsonIgnore]
        public string Password { get; set; }
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(25)]
        [Required]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        [Required]
        public string Phone { get; set; }
        [StringLength(20)]
        [Required]
        public string Country { get; set; }
        [StringLength(20)]
        [Required]
        public string UserName { get; set; }
        [StringLength(15)]
        [Required]
        public string City { get; set; }
    }
    public class User : IdentityUser<Guid>
    {
        public User()
        {

        }
        public User(string Email) : base(Email)
        {

        }
        [JsonIgnore]
        public string Password { set; get; }
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
        public DateTime dateTime { get; set; }
        public bool Gender { get; set; }
    }
}
