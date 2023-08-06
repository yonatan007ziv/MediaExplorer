using System;
using Xamarin.Forms;

namespace MediaExplorer.Models
{
    public class MovieInfoModel
    {
        public string Name { get; set; }
        public Uri MovieUri { get; set; }
        public bool MovieUriFound { get; set; }
        public string Description { get; set; } = "No Description Found...";
        public bool DescriptionFound { get; set; }
        public Uri TrailerUri { get; set; }
        public bool TrailerUriFound { get; set; }
        public ImageSource ImageSrc { get; set; }
        public bool ImageUriFound { get; set; }
    }
}