using Android.Widget;
using Java.Lang;

namespace Cumulus.ViewModels
{
    public class ListRowViewModel : Object
    {
        public ListRowViewModel(TextView textView, ImageView imageView)
        {
            TextView = textView;
            ImageView = imageView;
        }

        public ImageView ImageView { get; private set; }
        public TextView TextView { get; private set; }

        public void Update(string text, int fileImageResourceId)
        {
            TextView.Text = text;
            ImageView.SetImageResource(fileImageResourceId);
        }
    }
}