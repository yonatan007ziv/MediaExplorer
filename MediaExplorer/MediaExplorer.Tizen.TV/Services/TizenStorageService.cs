using MediaExplorer.Enums;
using MediaExplorer.Interfaces;
using MediaExplorer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tizen.System;

namespace MediaExplorer.Tizen.TV.Services
{
    internal class TizenStorageService : IStorageService
    {
        public event EventHandler StorageDevicesChanged;

        public TizenStorageService()
        {
            RegisterStorageChangedEvent();
        }

        public List<StorageInfoModel> GetStorageDevicesInfo()
        {
            List<StorageInfoModel> devices = new List<StorageInfoModel>();
            var storages = StorageManager.Storages.Where(s => s.StorageType != StorageArea.Internal);
            foreach (var storage in storages)
            {
                devices.Add(new StorageInfoModel
                {
                    Id = storage.Id,
                    Name = storage.RootDirectory.Split('/')[3],
                    Type = StorageType.SSD,
                    Size = storage.TotalSpace,
                    FreeSize = storage.AvailableSpace,
                    RootPath = storage.RootDirectory
                });
            }
            return devices;
        }

        private void RegisterStorageChangedEvent()
        {
            StorageManager.SetChangedEvent(StorageArea.External, (s, e) => StorageDevicesChanged.Invoke(s, e));
        }

        public List<DirectoryInfoModel> GetDirectoriesInfo(StorageInfoModel fromStorage, string fullPath)
        {
            List<DirectoryInfoModel> directories = new List<DirectoryInfoModel>();
            var storage = StorageManager.Storages.Where(s => s.StorageType != StorageArea.Internal && s.Id == fromStorage.Id).FirstOrDefault();
            string[] DirectoryNames = Directory.GetDirectories(fullPath).Where(IsNotMovieDirectory).ToArray();
            foreach(string directory in DirectoryNames)
            {
                directories.Add(new DirectoryInfoModel
                {
                    DirectoryName = directory.Split('/')[directory.Split('/').Length - 1],
                    FullPath = directory,
                    ParentStorage = fromStorage
                });
            }
            return directories;
        }

        public List<MovieInfoModel> GetMoviesInfo(StorageInfoModel fromStorage, string fullPath)
        {
            List<MovieInfoModel> movies = new List<MovieInfoModel>();
            var storage = StorageManager.Storages.Where(s => s.StorageType != StorageArea.Internal && s.Id == fromStorage.Id).FirstOrDefault();
            string[] MovieDirectoryNames = Directory.GetDirectories(fullPath).Where(IsMovieDirectory).ToArray();
            foreach (string directory in MovieDirectoryNames)
            {
                MovieInfoModel movieModel = new MovieInfoModel();
                movieModel.Name = directory.Substring(directory.LastIndexOf('/') + 1);

                if (movieModel.DescriptionFound = File.Exists($"{directory}/Description.txt"))
                    movieModel.Description = File.ReadAllText($"{directory}/Description.txt");
                if (movieModel.MovieUriFound = File.Exists($"{directory}/{movieModel.Name}.mp4"))
                    movieModel.MovieUri = new Uri($"{directory}/{movieModel.Name}.mp4");
                if (movieModel.TrailerUriFound = File.Exists($"{directory}/Trailer.mp4"))
                    movieModel.TrailerUri = new Uri($"{directory}/Trailer.mp4");
                if (movieModel.ImageUriFound = File.Exists($"{directory}/Image.png"))
                    movieModel.ImageSrc = new Uri($"{directory}/Image.png");
                movies.Add(movieModel);
            }
            return movies;
        }

        private bool IsMovieDirectory(string fullPath)
        {
            return ContainsMP4(fullPath);
        }

        private bool IsNotMovieDirectory(string fullPath)
        {
            return !IsMovieDirectory(fullPath);
        }

        private bool ContainsMP4(string path)
        {
            if (!Directory.Exists(path))
                return false;

            string[] mp4Files = Directory.GetFiles(path, "*.mp4");
            return mp4Files.Length > 0;
        }
    }
}