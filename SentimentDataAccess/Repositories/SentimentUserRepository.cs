using SentimentDataAccess.Context;
using SentimentDataAccess.Interfaces;
using SentimentModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentDataAccess.Repositories
{
    public class SentimentUserRepository : BaseRepository<SentimentUser, SentimentContext>, ISentimentUserRepository
    {
        public virtual void DisableUser(long oid)
        {
            var user = Get(oid);
            user.IsEnabled = false;
            Update(user);
        }
    }
}
