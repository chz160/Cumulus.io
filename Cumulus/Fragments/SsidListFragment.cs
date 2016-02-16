using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cumulus.Adapters;

namespace Cumulus.Fragments
{
    public class SsidListFragment : ListFragment
    {
        private SsidListAdapter _adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var configuredNetworks = ((WifiManager)Activity.GetSystemService(Context.WifiService)).ConfiguredNetworks;

            _adapter = new SsidListAdapter(Activity, configuredNetworks);
            ListAdapter = _adapter;
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var wifiConfiguration = _adapter.GetItem(position);

            Log.Verbose("FileListFragment", "The file {0} was clicked.", wifiConfiguration.Ssid);
            Toast.MakeText(Activity, "You selected file " + wifiConfiguration.Ssid, ToastLength.Short).Show();

            base.OnListItemClick(l, v, position, id);
        }

        public override void OnResume()
        {
            base.OnResume();
            RefreshFilesList();
        }

        public void RefreshFilesList()
        {
            var configuredNetworks = ((WifiManager)Activity.GetSystemService(Context.WifiService)).ConfiguredNetworks;
            _adapter.AddDirectoryContents(configuredNetworks);
            ListView.RefreshDrawableState();
        }
    }
}