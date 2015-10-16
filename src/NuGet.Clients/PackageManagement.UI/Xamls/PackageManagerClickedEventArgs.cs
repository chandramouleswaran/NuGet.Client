using System;
using NuGet.VisualStudio;

namespace NuGet.PackageManagement.UI
{
    public class PackageManagerClickedEventArgs : EventArgs
    {
        public PackageManagerClickedEventArgs(IVsPackageManagerProvider packageManagerProvider)
        {
            PackageManagerProvider = packageManagerProvider;
        }

        public IVsPackageManagerProvider PackageManagerProvider
        {
            get;
            private set;
        }        
    }
}