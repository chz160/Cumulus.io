using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Net.Wifi;
using Android.Views;
using Android.Widget;
using Cumulus.ViewModels;

namespace Cumulus.Adapters
{
    public class SsidListAdapter : ArrayAdapter<WifiConfiguration>
    {
        private readonly Context _context;

        public SsidListAdapter(Context context, IList<WifiConfiguration> fsi)
            : base(context, Resource.Layout.ssid_picker_list_item, Android.Resource.Id.Text1, fsi)
        {
            _context = context;
        }

        public void AddDirectoryContents(IEnumerable<WifiConfiguration> configuredNetworks)
        {
            Clear();
            if (configuredNetworks.Any())
            {
                AddAll(configuredNetworks.ToArray());
                NotifyDataSetChanged();
            }
            else
            {
                NotifyDataSetInvalidated();
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var networkEntry = GetItem(position);

            ListRowViewModel viewModel;
            View row;
            if (convertView == null)
            {
                row = _context.GetLayoutInflater().Inflate(Resource.Layout.ssid_picker_list_item, parent, false);
                viewModel = new ListRowViewModel(row.FindViewById<TextView>(Resource.Id.file_picker_text), row.FindViewById<ImageView>(Resource.Id.file_picker_image));
                row.Tag = viewModel;
            }
            else
            {
                row = convertView;
                viewModel = (ListRowViewModel)row.Tag;
            }
            viewModel.Update(networkEntry.Ssid, Resource.Drawable.file);

            return row;
        }
    }
}