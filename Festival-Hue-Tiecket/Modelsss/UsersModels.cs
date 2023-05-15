using Festival_Hue_Tiecket.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Modelsss
{
    public class UsersModels
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int SDT { get; set; }
        public Roles Roles { get; set; }
    }
}
