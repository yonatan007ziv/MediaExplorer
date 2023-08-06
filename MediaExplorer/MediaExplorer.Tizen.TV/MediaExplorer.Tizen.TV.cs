using MediaExplorer.Tizen.TV.Services;

namespace MediaExplorer.Tizen.TV
{
    internal class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            global::Xamarin.Forms.Platform.Tizen.Forms.Init(app);

            Xamarin.Forms.DependencyService.Register<TizenStorageService>();
            Xamarin.Forms.DependencyService.Register<TizenLogger>();
            Xamarin.Forms.DependencyService.Register<TizenMediaPlayerService>();
            Xamarin.Forms.DependencyService.Register<TizenPermissionService>();

            app.Run(args);
        }
    }
}
