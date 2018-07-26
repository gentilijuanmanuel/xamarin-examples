using System;
using Android.Support.V7.Widget;

namespace ExampleCustomTable
{
    public class ScrollListenerRightTopImplementation : RecyclerView.OnScrollListener
    {
        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            Console.WriteLine($"Right top wants to scroll rv: {dx}");

            if(MainActivity.topMustScrollBecauseOfRv)
            {
                MainActivity.topMustScrollBecauseOfRv = false;
            }
            else
            {
                MainActivity.rvMustScrollBecauseOfTop = true;
                //MainActivity.rvRightDown.SmoothScrollBy(dx, 0);
                //MainActivity.horizontalScrollViewRightBottom.ScrollBy(dx, 0);
            }

            base.OnScrolled(recyclerView, dx, dy);

            //void ScrollViewLeftDown_ScrollChange(object sender, View.ScrollChangeEventArgs e)
            //{
            //    if (leftMustScrollBecauseOfRv)
            //    {
            //        Console.WriteLine("leftMustScrollBecauseOfRv");
            //        leftMustScrollBecauseOfRv = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Left wants to scroll RV by {e.ScrollY}");
            //        rvMustScrollBecauseOfLeft = true;
            //        rv1.SmoothScrollBy(0, e.ScrollY);
            //    }
            //}
        }
    }
}
