using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;

namespace ExampleCustomTable
{
    public class ScrollListenerLeftDownImplementation : RecyclerView.OnScrollListener
    {
        public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
        {
            base.OnScrollStateChanged(recyclerView, newState);
            if(newState == RecyclerView.ScrollStateIdle)
                recyclerView.RemoveOnScrollListener(this);
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);

            MainActivity.rvRightDown.ScrollBy(dx, dy);
        }
    }


    [Register("exampleCustomTable.MyRecyclerView")]
    public class MyRecyclerView : RecyclerView
    {
        public MyRecyclerView(Context context) : base(context)
        {
        }

        public MyRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public MyRecyclerView TargetToScroll { get; set; }
    }
}
