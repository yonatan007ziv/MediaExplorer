using MediaExplorer.Models;
using MediaExplorer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaExplorer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectorySelectButton : ContentView
    {
        public DirectorySelectButton(DirectoryInfoModel directoryInfoModel)
        {
            InitializeComponent();
            BindingContext = new DirectorySelectButtonViewModel(directoryInfoModel);
        }
    }
}