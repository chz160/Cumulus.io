using System.IO;
using Android.Content;
using Android.Runtime;
using Android.Views;

namespace Cumulus
{
    public static class Helpers
    {
        public static LayoutInflater GetLayoutInflater(this Context context)
        {
            return context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
        }

        public static bool IsDirectory(this FileSystemInfo fsi)
        {
            if (fsi == null || !fsi.Exists)
            {
                return false;
            }
            return (fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory;
        }

        public static bool IsFile(this FileSystemInfo fsi)
        {
            if (fsi == null || !fsi.Exists)
            {
                return false;
            }
            return !IsDirectory(fsi);
        }

        public static bool IsVisible(this FileSystemInfo fsi)
        {
            if (fsi == null || !fsi.Exists)
            {
                return false;
            }
            var isHidden = (fsi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
            return !isHidden;
        }
    }
}