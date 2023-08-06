using MediaExplorer.Models;
using System;
using System.Collections.Generic;

namespace MediaExplorer.Interfaces
{
    public interface IStorageService
    {
        event EventHandler StorageDevicesChanged;
        List<StorageInfoModel> GetStorageDevicesInfo();
        List<DirectoryInfoModel> GetDirectoriesInfo(StorageInfoModel fromStorage, string localPath = "");
        List<MovieInfoModel> GetMoviesInfo(StorageInfoModel fromStorage, string localPath = "");
    }
}