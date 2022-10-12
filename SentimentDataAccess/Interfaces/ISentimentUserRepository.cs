using SentimentModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentDataAccess.Interfaces
{
    public interface ISentimentUserRepository : IRepository<SentimentUser>
    {
        void DisableUser(long oid);
    }
}
