using MediaExplorer.Enums;
using MediaExplorer.Models;
using MediaExplorer.Services;
using MediaExplorer.Views;
using Microsoft.Extensions.Logging;
using Xamarin.Forms;

namespace MediaExplorer.ViewModels
{
    public class StorageSelectButtonViewModel : BindableObject
    {
        private readonly ILogger _logger;
        private readonly StorageInfoModel _model;

        public string Name
        {
            get
            {
                return _model.Name;
            }
            private set
            {
                _model.Name = value;
                OnPropertyChanged();
            }
        }
        public StorageType Type
        {
            get
            {
                return _model.Type;
            }
            private set
            {
                _model.Type = value;
                OnPropertyChanged();
            }
        }
        public ulong Size
        {
            get
            {
                return _model.Size;
            }
            private set
            {
                _model.Size = value;
                OnPropertyChanged();
            }
        }
        public ulong FreeSize
        {
            get
            {
                return _model.FreeSize;
            }
            private set
            {
                _model.FreeSize = value;
                OnPropertyChanged();
            }
        }
        public string RootPath
        {
            get
            {
                return _model.RootPath;
            }
            private set
            {
                _model.RootPath = value;
                OnPropertyChanged();
            }
        }
        public Command SelectStorage { get; }

        public StorageSelectButtonViewModel(StorageInfoModel model)
        {
            _logger = DependencyService.Get<ILogger>();
            _model = model;
            SelectStorage = new Command(ClickedStorage);
        }

        private void ClickedStorage()
        {
            _logger.LogInformation($"Clicked on Drive: {Name}");
            NavigationHandler.Instance.NavigateTo(new StorageExplorerView(_model, new DirectoryInfoModel { DirectoryName = "", FullPath = _model.RootPath, ParentStorage = _model }));
        }
    }
}