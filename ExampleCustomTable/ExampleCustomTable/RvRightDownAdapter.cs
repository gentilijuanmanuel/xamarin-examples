using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace ExampleCustomTable
{
    public class RvRightDownAdapter : RecyclerView.Adapter
    {
        private MainActivity mainActivity;

        public RvRightDownAdapter(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

        public override int ItemCount
        {
            get { return 48; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                                          Inflate(Resource.Layout.item_adapter, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView);

            return vh;
        }
    }
}
