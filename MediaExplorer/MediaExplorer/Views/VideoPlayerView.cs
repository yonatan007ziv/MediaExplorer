using Xamarin.Forms;

namespace MediaExplorer.Views
{
    public class VideoPlayerView : View
    {
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(VideoPlayerView), default(string));

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
    }
}