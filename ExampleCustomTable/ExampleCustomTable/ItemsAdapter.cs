using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace ExampleCustomTable
{
    public class ItemsAdapter : BaseAdapter
    {
        Context context;

        public ItemsAdapter(Context c)
        {
            context = c;

            for (int i = 0; i < 200; i++)
                this.thumbIds.Add(Resource.Drawable.sample_0);
        }

        public override int Count
        {
            get { return thumbIds.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return 0;
        }

        // create a new ImageView for each item referenced by the Adapter
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView imageView;

            if (convertView == null)
            {
                imageView = new ImageView(context);
                imageView.LayoutParameters = new GridView.LayoutParams(200, 200);
                imageView.SetScaleType(ImageView.ScaleType.FitXy);
            }
            else
            {
                imageView = (ImageView)convertView;
            }

            imageView.SetImageResource(thumbIds[position]);
            return imageView;
        }

        List<int> thumbIds = new List<int>();
    }
}
