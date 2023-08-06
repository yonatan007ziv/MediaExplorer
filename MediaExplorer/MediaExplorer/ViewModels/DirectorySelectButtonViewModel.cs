using MediaExplorer.Models;
using MediaExplorer.Services;
using MediaExplorer.Views;
using Microsoft.Extensions.Logging;
using Xamarin.Forms;

namespace MediaExplorer.ViewModels
{
    internal class DirectorySelectButtonViewModel : BindableObject
    {
        private readonly ILogger _logger;
        private readonly DirectoryInfoModel _model;

        public string DirectoryName
        {
            get 
            {
                return _model.DirectoryName;
            }
            set
            {
                _model.DirectoryName = value;
                OnPropertyChanged();
            }
        }
        public string LocalPath
        {
            get 
            {
                return _model.FullPath;
            }
            set
            {
                _model.FullPath = value;
                OnPropertyChanged();
            }
        }
        public Command SelectDirectory { get; }

        public DirectorySelectButtonViewModel(DirectoryInfoModel directory)
        {
            _logger = DependencyService.Get<ILogger>();
            _model = directory;
            SelectDirectory = new Command(ClickedDirectory);
        }

        private void ClickedDirectory()
        {
            _logger.LogInformation($"Clicked on Directory: {DirectoryName}");
            NavigationHandler.Instance.NavigateTo(new StorageExplorerView(_model.ParentStorage, _model));
        }
    }
}