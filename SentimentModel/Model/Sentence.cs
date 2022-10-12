using System;
using SentimentModel.Interface;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SentimentModel.Model
{
    [Table("Sentences")]
    public class Sentence : IOID
    {
        [Key]
        public long OID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }


        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
