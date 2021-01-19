using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JahresUrlaub.Web.Models
{
    /// <summary>
    /// Class für Reset neu Password falls den Benutzer sein Password vergessen hat 
    /// </summary>
    public class ResetPassword
    {
        [Required(ErrorMessage ="Neue Password ist Erfolgreich" , AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        public string NewPassword {get;set;}
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Neue Password und Confrim Password müssen gleiche sein")]
        public string ConfrimPassword {get;set;}
        [Required]
        public string ResetCode {get;set;}
    }
}