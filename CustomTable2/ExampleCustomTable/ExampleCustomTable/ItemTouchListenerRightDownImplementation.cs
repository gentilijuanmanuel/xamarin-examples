using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace ExampleCustomTable
{
    //here is the problem
    public class ItemTouchListenerRightDownImplementation : RecyclerView.SimpleOnItemTouchListener
    {
        private int mLastY;
        private ScrollListenerRightDownImplementation scrollListenerRightDown;

        public override bool OnInterceptTouchEvent(RecyclerView rv, MotionEvent e)
        {
            bool ret = rv.ScrollState != RecyclerView.ScrollStateIdle;
            if (!ret)
            {
                OnTouchEvent(rv, e);
            }
            return false;
        }

        public override void OnTouchEvent(RecyclerView rv, MotionEvent e)
        {
            var action = e.Action;

            if (action == MotionEventActions.Down && MainActivity.rvLeftDown.ScrollState == RecyclerView.ScrollStateIdle)
            {
                mLastY = rv.ScrollY;
                //mLastY = (int)e.YPrecision;
                //mLastY = (int)rv.GetY();
                //Console.WriteLine($"mLastY {mLastY}");
                this.scrollListenerRightDown = new ScrollListenerRightDownImplementation();
                rv.AddOnScrollListener(this.scrollListenerRightDown);
            }
            else
            {
                //Console.WriteLine($"mLastY {mLastY} - {rv.ScrollY}");
                //int y = (int)rv.GetY();

                if (action == MotionEventActions.Up && rv.ScrollY == mLastY)
                {
                    Console.WriteLine($"mLastY {mLastY}; scrollY {rv.ScrollY}");
                    rv.RemoveOnScrollListener(this.scrollListenerRightDown);
                }
            }
        }

        public override void OnRequestDisallowInterceptTouchEvent(bool disallowIntercept)
        {

        }
    }
}