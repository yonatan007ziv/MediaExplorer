using MediaExplorer.Interfaces;
using MediaExplorer.Views;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace MediaExplorer.ViewModels
{
    internal class StorageSelectionViewModel : BindableObject
    {
        private readonly IStorageService _storageManager;
        private readonly StackLayout storageStackLayout;

        public ObservableCollection<StorageSelectButton> StorageButtons { get; }

        public StorageSelectionViewModel(StackLayout storageStackLayout)
        {
            this.storageStackLayout = storageStackLayout;
            StorageButtons = new ObservableCollection<StorageSelectButton>();
            StorageButtons.CollectionChanged += UpdateLayout;
            _storageManager = DependencyService.Get<IStorageService>();
            _storageManager.StorageDevicesChanged += (s, e) => RefreshStorages();
            RefreshStorages();
        }

        private void UpdateLayout(object sender, NotifyCollectionChangedEventArgs e)
        {
            storageStackLayout.Children.Clear();
            foreach (var button in StorageButtons)
                storageStackLayout.Children.Add(button);
        }

        public void RefreshStorages()
        {
            StorageButtons.Clear();
            var storages = _storageManager.GetStorageDevicesInfo();
            foreach (var storageDevice in storages)
                StorageButtons.Add(new StorageSelectButton(storageDevice));
        }
    }
}