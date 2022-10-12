using SentimentModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentDataAccess.Interfaces
{
    public interface ISentenceRepository : IRepository<Sentence>
    {
        Sentence GetRandomSentence();
    }
}
