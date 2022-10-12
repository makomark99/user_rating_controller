using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentDataAccess.Configuration
{
    public static class SentimentDbConfiguration
    {
        public static string GetConnectionString()
        {
            return @"Data Source=MARK-LAPTOP\OWN_SQL_SERVER;Initial Catalog=SentimentDb;Integrated Security=True;";
        }
    }
}
