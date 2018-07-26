using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace ExampleCustomTable
{
    public class ItemTouchListenerLeftDownImplementation : RecyclerView.SimpleOnItemTouchListener
    {
        private int mLastY;
        private ScrollListenerLeftDownImplementation scrollListenerLeftDown;

        public override bool OnInterceptTouchEvent(RecyclerView rv, MotionEvent e)
        {
            bool ret = rv.ScrollState != RecyclerView.ScrollStateIdle;
            if (!ret)
                OnTouchEvent(rv, e);
            return false;
        }

        public override void OnTouchEvent(RecyclerView rv, MotionEvent e)
        {
            var action = e.Action;

            if(action == MotionEventActions.Down && MainActivity.rvRightDown.ScrollState == RecyclerView.ScrollStateIdle)
            {
                mLastY = rv.ScrollY;
                //mLastY = (int)e.YPrecision;
                //mLastY = (int)rv.GetY();
                //Console.WriteLine($"mLastY LeftDown {mLastY}");
                this.scrollListenerLeftDown = new ScrollListenerLeftDownImplementation();
                rv.AddOnScrollListener(this.scrollListenerLeftDown);
            }
            else
            {
                Console.WriteLine($"mLastY LeftDown {mLastY}");
                //int y = (int)rv.GetY(); 

                if (action == MotionEventActions.Up && rv.ScrollY == mLastY)
                {
                    Console.WriteLine($"mLastY LeftDown {mLastY}; scrollY {rv.ScrollY}");
                    rv.RemoveOnScrollListener(this.scrollListenerLeftDown);
                }
            }
        }

        public override void OnRequestDisallowInterceptTouchEvent(bool disallowIntercept)
        {

        }
    }
}