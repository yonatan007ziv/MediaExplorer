using MediaExplorer.Interfaces;
using MediaExplorer.Models;
using MediaExplorer.Services;
using MediaExplorer.Views;
using System;
using Xamarin.Forms;

namespace MediaExplorer.ViewModels
{
    internal class MovieSelectButtonViewModel : BindableObject
    {
        private readonly MovieInfoModel _model;
        private readonly IMediaPlayerService _mediaPlayer;

        public string Name
        {
            get { return _model.Name; }
            set
            {
                _model.Name = value;
                OnPropertyChanged();
            }
        }
        public Uri MovieUri
        {
            get { return _model.MovieUri; }
            set
            {
                _model.MovieUri = value;
                OnPropertyChanged();
            }
        }
        public bool MovieUriFound
        {
            get { return _model.MovieUriFound; }
            set
            {
                _model.MovieUriFound = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return _model.Description; }
            set
            {
                _model.Description = value;
                OnPropertyChanged();
            }
        }
        public bool DescriptionFound
        {
            get { return _model.DescriptionFound; }
            set
            {
                _model.DescriptionFound = value;
                OnPropertyChanged();
            }
        }
        public Uri TrailerUri
        {
            get { return _model.TrailerUri; }
            set
            {
                _model.TrailerUri = value;
                OnPropertyChanged();
            }
        }
        public bool TrailerUriFound
        {
            get { return _model.TrailerUriFound; }
            set
            {
                _model.TrailerUriFound = value;
                OnPropertyChanged();
            }
        }
        public ImageSource ImageSrc
        {
            get { return _model.ImageSrc; }
            set
            {
                _model.ImageSrc = value;
                OnPropertyChanged();
            }
        }
        public bool ImageUriFound
        {
            get { return _model.ImageUriFound; }
            set
            {
                _model.ImageUriFound = value;
                OnPropertyChanged();
            }
        }
        public Command PlayMovie { get; }
        public Command PlayTrailer { get; }

        public MovieSelectButtonViewModel(MovieInfoModel movieInfoModel)
        {
            _model = movieInfoModel;
            _mediaPlayer = DependencyService.Get<IMediaPlayerService>();

            PlayMovie = new Command(MoviePlay);
            PlayTrailer = new Command(TrailerPlay);
        }

        private void MoviePlay()
        {
            VideoPlayerView a = new VideoPlayerView();
            NavigationHandler.Instance.CurrentView.Content = a;
            _mediaPlayer.SetSource(MovieUri);
            _mediaPlayer.Play();
        }

        private void TrailerPlay()
        {
            _mediaPlayer.SetSource(TrailerUri);
            _mediaPlayer.Play();
        }
    }
}