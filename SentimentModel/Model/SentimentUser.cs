using System;
using SentimentModel.Interface;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SentimentModel.Model
{
    [Table("SentimentUsers")]
    public class SentimentUser : IOID
    {
        [Key]
        public long OID { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

    }
}
