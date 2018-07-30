using System;
using Android.Support.V7.Widget;

namespace ExampleCustomTable
{
    public class PositionTrackingOnScrollListener : RecyclerView.OnScrollListener
    {
        public int ScrolledY { get; set; }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            this.ScrolledY += dy;
            base.OnScrolled(recyclerView, dx, dy);
        }
    }
}
