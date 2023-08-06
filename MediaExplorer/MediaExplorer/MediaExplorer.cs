using MediaExplorer.Interfaces;
using MediaExplorer.Services;
using MediaExplorer.Views;
using Xamarin.Forms;

namespace MediaExplorer
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new MainPage();

            Device.BeginInvokeOnMainThread(() => DependencyService.Get<IPermissionService>().CheckStoragePermission());
            NavigationHandler.Instance.NavigateTo(new StorageSelectionView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
