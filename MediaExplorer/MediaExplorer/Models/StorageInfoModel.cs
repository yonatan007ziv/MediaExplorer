using MediaExplorer.Enums;

namespace MediaExplorer.Models
{
    public class StorageInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StorageType Type { get; set; }
        public ulong Size{ get; set; }
        public ulong FreeSize{ get; set; }
        public string RootPath { get; set; }
    }
}
