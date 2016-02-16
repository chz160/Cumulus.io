using Android.App;
using Android.Content;
using Android.Net;
using Android.Net.Wifi;
using Cumulus.Activities;

namespace Cumulus
{
    [BroadcastReceiver]
    [IntentFilter(new[] { WifiManager.NetworkStateChangedAction }, Priority = (int)IntentFilterPriority.HighPriority)]
    public class WifiConnectionMadeBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var connectivityManager = (ConnectivityManager)context.GetSystemService(Context.ConnectivityService);
            var info = connectivityManager.ActiveNetworkInfo;
            if (info != null && info.IsConnected)
            {
                //do stuff
                var wifiManager = (WifiManager)context.GetSystemService(Context.WifiService);
                var wifiInfo = wifiManager.ConnectionInfo;
                var ssid = wifiInfo.SSID;
                if (ssid == "\"jackstack\"")
                {
                    var nMgr = (NotificationManager)context.GetSystemService(Context.NotificationService);
                    //var notification = new Notification(Resource.Drawable.icon, $"Connected to {ssid}!");
                    var pendingIntent = PendingIntent.GetActivity(context, 0, new Intent(context, typeof(MainActivity)), 0);
                    //notification.SetLatestEventInfo(context, "Wifi Connected", "Wifi Connected Detail", pendingIntent);
                    var notification = new Notification.Builder(context)
                        .SetSmallIcon(Resource.Drawable.icon)
                        .SetTicker($"Connected to {ssid}!")
                        .SetContentTitle("Wifi Connected")
                        .SetContentText("Wifi Connected Detail")
                        .SetContentIntent(pendingIntent)
                        .Build();
                    nMgr.Notify(0, notification);
                }
            }
        }
    }
}