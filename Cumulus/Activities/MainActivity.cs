using Android.App;
using Android.OS;
using Android.Widget;

namespace Cumulus.Activities
{
    [Activity(Label = "Cumulus.IO", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);

            ((Button)FindViewById(Resource.Id.buttonFolders)).Click += ButtonFolders_Click;
            ((Button)FindViewById(Resource.Id.buttonSSIDs)).Click += ButtonSSIDs_Click;
        }

        private void ButtonSSIDs_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(SsidActivity));
        }

        private void ButtonFolders_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(FolderActivity));
        }
    }
}

