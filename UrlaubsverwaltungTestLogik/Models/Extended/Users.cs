using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JahresUrlaub.Web.Models
{

    [MetadataType(typeof(UserMetdata))]
    public  partial class Users
    {
        public string ConfirmPassword { get; set; }

    }
    public class UserMetdata
    {
        [Display(Name ="First Name")]
        [Required(AllowEmptyStrings =false , ErrorMessage ="Vorname ist Erfolgreich")]
        public string Firtsname { get; set; }
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nachname ist Erfolgreich")]
        public string Lastname { get; set; }
        [Display(Name ="Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ist Erfolgreich")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Date of Brith")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Geburtsdatum ist Erfolgreich")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Required(AllowEmptyStrings =false , ErrorMessage ="Password ist Erfolgreich")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Mindesten 6 Zeichen bitte in password")]
        public string Password { get; set; }
        [Display(Name ="Confrim Password")]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage ="Confirm password muss abstimmen")]
        public string ConfirmPassword { get; set; }




    }
}