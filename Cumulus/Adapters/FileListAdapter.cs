using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using Cumulus.ViewModels;

namespace Cumulus.Adapters
{
    public class FileListAdapter : ArrayAdapter<FileSystemInfo>
    {
        private readonly Context _context;

        public FileListAdapter(Context context, IList<FileSystemInfo> fsi)
            : base(context, Resource.Layout.file_picker_list_item, Android.Resource.Id.Text1, fsi)
        {
            _context = context;
        }

        public void AddDirectoryContents(IEnumerable<FileSystemInfo> directoryContents)
        {
            Clear();
            if (directoryContents.Any())
            {
                AddAll(directoryContents.ToArray());
                NotifyDataSetChanged();
            }
            else
            {
                NotifyDataSetInvalidated();
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var fileSystemEntry = GetItem(position);

            ListRowViewModel viewModel;
            View row;
            if (convertView == null)
            {
                row = _context.GetLayoutInflater().Inflate(Resource.Layout.file_picker_list_item, parent, false);
                viewModel = new ListRowViewModel(row.FindViewById<TextView>(Resource.Id.file_picker_text), row.FindViewById<ImageView>(Resource.Id.file_picker_image));
                row.Tag = viewModel;
            }
            else
            {
                row = convertView;
                viewModel = (ListRowViewModel)row.Tag;
            }
            viewModel.Update(fileSystemEntry.Name, fileSystemEntry.IsDirectory() ? Resource.Drawable.folder : Resource.Drawable.file);

            return row;
        }
    }
}