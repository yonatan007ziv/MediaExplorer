using MediaExplorer.Models;
using MediaExplorer.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaExplorer.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StorageExplorerView : ContentView
    {
        public StorageExplorerView(StorageInfoModel storageInfoModel, DirectoryInfoModel contextDir)
        {
            InitializeComponent();
            BindingContext = new StorageExplorerViewModel(storageInfoModel, contextDir, _directoryStackLayout, _moviesStackLayout);
        }
    }
}