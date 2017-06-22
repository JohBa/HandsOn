using System;
using Xamarin.Forms;

namespace AIT_XamarinCommunityEvent
{

    public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new TodoList();
		}

        public static IAuthenticate Authenticator { get; private set; }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        protected override async void OnStart ()
        {
            // Handle when your app starts
            await Authenticator.Authenticate();
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

