using SentimentDataAccess.Context;
using SentimentDataAccess.Interfaces;
using SentimentModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SentimentDataAccess.Repositories
{
    public class SentenceRepository : BaseRepository<Sentence, SentimentContext>, ISentenceRepository
    {
        public Sentence GetRandomSentence()
        {
            var oids = GetAll().Select(x => x.OID).ToArray();
            var rnd = new Random();
            var index = rnd.Next(0, oids.Length);
            var oid = oids[index];

            return Get(oid);
        }
    }
}
