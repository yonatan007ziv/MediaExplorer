using MediaExplorer.Interfaces;
using MediaExplorer.Models;
using MediaExplorer.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace MediaExplorer.ViewModels
{
    internal class StorageExplorerViewModel : BindableObject
    {
        private readonly IStorageService _storageManager;
        private readonly StorageInfoModel _storage;
        private readonly DirectoryInfoModel _dir;
        private readonly StackLayout directoryStackLayout;
        private readonly StackLayout moviesStackLayout;

        public ObservableCollection<DirectorySelectButton> DirectoryButtons { get; }
        public ObservableCollection<MovieSelectButton> MovieButtons { get; }

        public StorageExplorerViewModel(StorageInfoModel storage, DirectoryInfoModel contextDir, StackLayout directoryStackLayout, StackLayout moviesStackLayout)
        {
            _storageManager = DependencyService.Get<IStorageService>();
            _storage = storage;
            _dir = contextDir;
            this.directoryStackLayout = directoryStackLayout;
            this.moviesStackLayout = moviesStackLayout;

            DirectoryButtons = new ObservableCollection<DirectorySelectButton>();
            DirectoryButtons.CollectionChanged += UpdateDirectoriesLayout;
            AddDirectories();

            MovieButtons = new ObservableCollection<MovieSelectButton>();
            MovieButtons.CollectionChanged += UpdateMoviesLayout;
            AddMovies();
        }

        private void UpdateDirectoriesLayout(object sender, NotifyCollectionChangedEventArgs e)
        {
            directoryStackLayout.Children.Clear();
            foreach (var button in DirectoryButtons)
                directoryStackLayout.Children.Add(button);
        }

        public void AddDirectory(DirectoryInfoModel directory)
        {
            DirectoryButtons.Add(new DirectorySelectButton(directory));
        }

        private void AddDirectories()
        {
            List<DirectoryInfoModel> directories = _storageManager.GetDirectoriesInfo(_storage, _dir.FullPath);
            foreach (DirectoryInfoModel directory in directories)
                AddDirectory(directory);
        }

        private void UpdateMoviesLayout(object sender, NotifyCollectionChangedEventArgs e)
        {
            moviesStackLayout.Children.Clear();
            foreach (var button in MovieButtons)
                moviesStackLayout.Children.Add(button);
        }

        public void AddMovie(MovieInfoModel directory)
        {
            MovieButtons.Add(new MovieSelectButton(directory));
        }

        private void AddMovies()
        {
            List<MovieInfoModel> movies = _storageManager.GetMoviesInfo(_storage, _dir.FullPath);
            foreach (MovieInfoModel directory in movies)
                AddMovie(directory);
        }
    }
}