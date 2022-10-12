using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentBusinessLogic.ViewModels
{
    public class SentenceTextWithRating
    {
        public long OID { get; set; }
        public string Text { get; set; }
        public decimal RatingValue { get; set; }
    }
}
