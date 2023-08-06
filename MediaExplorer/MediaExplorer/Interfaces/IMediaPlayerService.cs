using MediaExplorer.Views;
using System;

namespace MediaExplorer.Interfaces
{
    public interface IMediaPlayerService
    {
        void Play();
        void SetSource(Uri uri);
        void Pause();
        void Stop();
    }
}