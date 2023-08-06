using MediaExplorer.Models;
using MediaExplorer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaExplorer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieSelectButton : ContentView
    {
        public MovieSelectButton(MovieInfoModel movieInfoModel)
        {
            InitializeComponent();
            BindingContext = new MovieSelectButtonViewModel(movieInfoModel);
        }
    }
}