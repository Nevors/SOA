using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain_User.Entity {
    public class Role {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Importance { get; set;}
    }
}