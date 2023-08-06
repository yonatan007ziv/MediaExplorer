namespace MediaExplorer.Models
{
    public class DirectoryInfoModel
    {
        public string DirectoryName { get; set; }
        public string FullPath { get; set; }
        public StorageInfoModel ParentStorage { get; set; }
    }
}