using SentimentDataAccess.Context;
using SentimentDataAccess.Interfaces;
using SentimentDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace SentimentDataAccess
{
    public class ModuleRegistration
    {
		private readonly UnityContainer _unityContainer;

		public ModuleRegistration(UnityContainer unityContainer)
		{
			_unityContainer = unityContainer;
		}

		public void Register()
		{
			_unityContainer.RegisterType<SentimentContext>();

			_unityContainer.RegisterType<IRatingRepository, RatingRepository>();
			_unityContainer.RegisterType<ISentenceRepository, SentenceRepository>();
			_unityContainer.RegisterType<ISentimentUserRepository, SentimentUserRepository>();
		}

	}
}
