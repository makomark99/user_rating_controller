using SentimentBusinessLogic.Managers;
using Unity;

namespace SentimentBusinessLogic
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
			_unityContainer.RegisterType<RatingManager>();
			_unityContainer.RegisterType<SentenceManager>();
		}
	}
}
