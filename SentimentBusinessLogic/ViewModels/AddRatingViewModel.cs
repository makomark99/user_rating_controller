using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentBusinessLogic.ViewModels
{
    public class AddRatingViewModel
    {
        public long SentenceOID { get; set; }
        public long SentimentUserOID { get; set; }
        public string SentenceText { get; set; }
    }
}
