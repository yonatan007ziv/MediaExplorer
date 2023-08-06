using MediaExplorer.Enums;
using MediaExplorer.Interfaces;
using System;
using Tizen.Security;

namespace MediaExplorer.Tizen.TV.Services
{
    internal class TizenPermissionService : IPermissionService
    {
        private const string STORAGE_PERMISSION_ID = "http://tizen.org/privilege/externalstorage";

        public PermissionStatus CheckStoragePermission()
        {
            CheckResult result = PrivacyPrivilegeManager.CheckPermission(STORAGE_PERMISSION_ID);
            switch (result)
            {
                case CheckResult.Allow:
                    return PermissionStatus.Allowed; 
                case CheckResult.Deny:
                    return PermissionStatus.Denied;
                case CheckResult.Ask:
                    return PermissionStatus.Ask;
            }
            throw new Exception();
        }

        public void RequestStoragePermission()
        {
            PrivacyPrivilegeManager.RequestPermission(STORAGE_PERMISSION_ID);

            PrivacyPrivilegeManager.GetResponseContext(STORAGE_PERMISSION_ID).TryGetTarget(out PrivacyPrivilegeManager.ResponseContext context);
            context.ResponseFetched += PPM_ResponseFetched;
        }

        private void PPM_ResponseFetched(object sender, RequestResponseEventArgs e)
        {
            Console.WriteLine();
        }
    }
}