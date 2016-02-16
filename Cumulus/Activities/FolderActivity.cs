using Android.App;
using Android.OS;

namespace Cumulus.Activities
{
    [Activity(Label = "Cumulus.IO", Icon = "@drawable/icon")]
    public class FolderActivity : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.folders);
        }
    }
}