using MediaExplorer.Models;
using MediaExplorer.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaExplorer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StorageSelectButton : ContentView
	{
		public StorageSelectButton(StorageInfoModel storageInfoModel)
		{
			InitializeComponent();
            BindingContext = new StorageSelectButtonViewModel(storageInfoModel);
        }
    }
}