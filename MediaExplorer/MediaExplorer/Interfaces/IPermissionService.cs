using MediaExplorer.Enums;

namespace MediaExplorer.Interfaces
{
    public interface IPermissionService
    {
        PermissionStatus CheckStoragePermission();
        void RequestStoragePermission();
    }
}