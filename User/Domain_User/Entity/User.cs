using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Domain_User.Entity {
    public class User {
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(30)]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}