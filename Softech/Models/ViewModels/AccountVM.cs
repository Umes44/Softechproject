using Softech.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;

namespace Softech.Models.ViewModels
{
    public class AccountVM
    {
        public AccountVM()
        {

        }
        public AccountVM(AccountDTO row)
        {
            Id = row.Id;
            FirstName = row.FirstName;
            LastName = row.LastName;
            Email = row.Email;
            Age = row.Age;
            Gender = row.Gender;
            UserName = row.UserName;
            Password = row.Password;

        }
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
      
    }
}