using MediaExplorer.Interfaces;
using MediaExplorer.Tizen.TV.Services;
using MediaExplorer.Views;
using System;
using System.ComponentModel;
using Tizen.Multimedia;
using Xamarin.Forms.Platform.Tizen;

[assembly: ExportRenderer(typeof(VideoPlayerView), typeof(TizenMediaPlayerService))]
namespace MediaExplorer.Tizen.TV.Services
{
    internal class TizenMediaPlayerService : ViewRenderer<VideoPlayerView, MediaView>, IMediaPlayerService
    {
        private Player _player;

        public void Play()
        {
            _player.Start();
        }

        public async void SetSource(Uri uri)
        {
            _player.SetSource(new MediaUriSource(uri.AbsoluteUri));
            await _player.PrepareAsync();
        }

        public void Pause()
        {
            _player.Pause();
        }

        public void Stop()
        {
            _player.Stop();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayerView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                SetNativeControl(new MediaView(Forms.NativeParent));

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= OnVideoPlayerViewPropertyChanged;
                _player.Dispose();
            }

            if (e.NewElement != null)
            {
                _player = new Player();
                _player.Display = new Display(Control);
                e.NewElement.PropertyChanged += OnVideoPlayerViewPropertyChanged;
            }
        }

        private void OnVideoPlayerViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == VideoPlayerView.SourceProperty.PropertyName)
                SetSource(new Uri(Element.Source));
        }
    }
}