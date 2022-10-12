using SentimentBusinessLogic.ViewModels;
using SentimentCore.DependencyInjection;
using SentimentDataAccess.Interfaces;
using SentimentModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentBusinessLogic.Managers
{
    public class RatingManager
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

        #endregion


        public AddRatingViewModel GetAddRatingViewModel()
        {
            var sentence = SentenceRepository().GetRandomSentence();
            var ratingViewModel = new AddRatingViewModel()
            {
                SentenceOID = sentence.OID,
                SentenceText = sentence.Text
            };
            ratingViewModel.SentimentUserOID = 1;
            return ratingViewModel;
        }



        public void PersistRating(long sentimentUserOid, long sentenceOid, bool? isPositive)
        {

            var rating = new Rating()
            {
                SentenceOID = sentenceOid,
                SentimentUserOID = sentimentUserOid,
                CreatedAt = DateTime.Now,
                IsPositive = isPositive
            };

            var ratingRepository = SDI.Resolve<IRatingRepository>();
            ratingRepository.Add(rating);

        }
    }
}
