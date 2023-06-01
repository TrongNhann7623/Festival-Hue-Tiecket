using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Modelsss
{
    public class Resetpassword
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Token { get; set; } = string.Empty;
        [System.ComponentModel.DataAnnotations.Required, MinLength(6, ErrorMessage = "at least 6 characters")]
        public string Password { get; set; } = string.Empty;
        [System.ComponentModel.DataAnnotations.Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
