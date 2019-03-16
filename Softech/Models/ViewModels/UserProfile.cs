using Softech.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softech.Models.ViewModels
{
    public class UserProfile
    {
        public UserProfile()
        {

        }
        public UserProfile(AccountDTO row)
        {
            UserId = row.UserId;
            FirstName = row.FirstName;
            LastName = row.LastName;
            Email = row.Email;
            Age = row.Age;
            Gender = row.Gender;
            UserName = row.UserName;
            Password = row.Password;

        }
        public int UserId { get; set; }
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
        public string ConfirmPassword { get; set; }
    }

}