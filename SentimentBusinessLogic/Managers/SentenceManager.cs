using Microsoft.EntityFrameworkCore;
using SentimentBusinessLogic.ViewModels;
using SentimentCore.DependencyInjection;
using SentimentDataAccess.Interfaces;
using SentimentModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SentimentBusinessLogic.Managers
{
    public class SentenceManager
    {
        #region lazy loaded objects

        private ISentenceRepository _sentenceRepository;
        private ISentenceRepository SentenceRepository()
        {
            if (_sentenceRepository == null)
            {
                _sentenceRepository = SDI.Resolve<ISentenceRepository>();
            }
            return _sentenceRepository;
        }

        private IRatingRepository _ratingRepository;
        private IRatingRepository RatingRepository()
        {
            if (_ratingRepository == null)
            {
                _ratingRepository = SDI.Resolve<IRatingRepository>();
            }
            return _ratingRepository;
        }

        #endregion

        public void SaveNewSentence(string text)
        {
            SentenceRepository().Add(new Sentence() { Text = text, CreatedAt = DateTime.Now });
        }

        public void SaveNewSentences(List<string> texts)
        {
            var now = DateTime.Now;
            var sentences = texts.Where(x => !string.IsNullOrWhiteSpace(x))
                                .Select(x => new Sentence() 
                                {
                                    Text = x,
                                    CreatedAt = now 
                                })
                                .ToList();
            SentenceRepository().AddRange(sentences);
        }

        public ListRatingsViewModel GetListRatingsViewModel()
        {
            var result = new ListRatingsViewModel()
            {
                SentenceTextWithRatings = new List<SentenceTextWithRating>()
            };

            var query1 = RatingRepository().GetAll().AsNoTracking().Where(x => x.IsPositive.HasValue).Include(x => x.Sentence).ToList();
            var query2 = query1.GroupBy(x => x.Sentence.OID);
            foreach (var item in query2)
            {
                var text = item.FirstOrDefault().Sentence.Text;
                var count = item.Count();
                var ratingSum = item.Where(x => x.IsPositive.Value).Count();
                var ratingValue = ratingSum / (decimal)count;

                result.SentenceTextWithRatings.Add(new SentenceTextWithRating() { Text = text, RatingValue = ratingValue, OID=item.Key });
            }

            return result;
        }
        public List<SentenceTextWithRating> GetSentenceTextWithRatings(long sentimentUserOid, int pageNumber)
        {
            const int pageSize = 10;
            var results = GetSentenceTextWithRatings(sentimentUserOid).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return results;

        }
        public string GetSentencesCsv()
        {
            var list = GetSentenceTextWithRatings();
            var sb = new StringBuilder();
            sb.Append("OID;SentenceText;Rating");
            foreach (var item in list)
            {
                sb.AppendLine(string.Format("{0};{1};{2}", item.OID, item.Text.Replace(";"," - "), item.RatingValue));
            }
            return sb.ToString();
        }
    }
}
