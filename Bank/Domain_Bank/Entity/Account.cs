using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain_Bank.Entity {
    public class Account {
        [Required]
        public int Id { get; set; }
        [Required]
        public int LoginId { get; set; }
        public decimal Balance { get; set; }
    }
}