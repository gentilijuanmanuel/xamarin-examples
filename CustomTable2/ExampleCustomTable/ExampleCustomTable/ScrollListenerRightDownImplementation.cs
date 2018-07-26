using System;
using Android.Support.V7.Widget;

namespace ExampleCustomTable
{
    public class ScrollListenerRightDownImplementation : RecyclerView.OnScrollListener
    {
        public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
        {
            base.OnScrollStateChanged(recyclerView, newState);
            if (newState == RecyclerView.ScrollStateIdle)
                recyclerView.RemoveOnScrollListener(this);
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);

            //Console.WriteLine($"RightDownRv coordinates: ({dx}, {dy})");

            MainActivity.rvLeftDown.ScrollBy(dx, dy);
        }
    }
}
