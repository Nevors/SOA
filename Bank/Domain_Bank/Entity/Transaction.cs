using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain_Bank.Entity {
    public class Transaction {
        public int Id { get;set;}
        public int AccountOutId { get; set; }
        public Account AccountOut { get; set; }
        public int AccountInId { get; set; }
        public Account AccountIn { get; set; }
        [Required]
        public decimal Count { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}