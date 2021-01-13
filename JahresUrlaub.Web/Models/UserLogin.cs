using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JahresUrlaub.Web.Models
{
    public class UserLogin
    {
        [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings =false ,ErrorMessage ="Email ist Erfolgreich")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password ist Erfolgreich")]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

    }
}