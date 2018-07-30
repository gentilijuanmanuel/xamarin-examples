using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace ExampleCustomTable
{
    public class RvLeftDownAdapter : RecyclerView.Adapter
    {
        private MainActivity mainActivity;

        public RvLeftDownAdapter(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

        public override int ItemCount
        {
            get { return 8; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
                                          Inflate(Resource.Layout.item_adapter_left_down, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView);
            return vh;
        }
    }
}