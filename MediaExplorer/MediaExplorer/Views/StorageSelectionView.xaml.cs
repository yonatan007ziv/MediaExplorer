using MediaExplorer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaExplorer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StorageSelectionView : ContentView
	{
        public StorageSelectionView()
        {
            InitializeComponent();
            BindingContext = new StorageSelectionViewModel(_storageStackLayout);
        }
    }
}