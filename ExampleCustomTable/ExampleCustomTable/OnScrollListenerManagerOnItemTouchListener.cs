using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace ExampleCustomTable
{
    public class OnScrollListenerManagerOnItemTouchListener : RecyclerView.SimpleOnItemTouchListener
    {
        private List<AligningRecyclerViewRelationship> aligningRecyclerViewRelationships = new List<AligningRecyclerViewRelationship>();
        private int mLastY;

        public override bool OnInterceptTouchEvent(RecyclerView rv, MotionEvent e)
        {
            bool ret = false;

            if (rv.ScrollState == RecyclerView.ScrollStateIdle)
                OnTouchEvent(rv, e);

            foreach (var item in aligningRecyclerViewRelationships)
            {
                if (item.rvFrom == rv && item.rvTo.ScrollState != RecyclerView.ScrollStateIdle)
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }

        public override void OnTouchEvent(RecyclerView rv, MotionEvent e)
        {
            foreach (var item in aligningRecyclerViewRelationships)
            {
                handleTouchEvent((AligningRecyclerView)rv, e, item.rvTo);
            }
        }

        private void handleTouchEvent(AligningRecyclerView from, MotionEvent e, AligningRecyclerView to)
        {
            var action = e.Action;
            PositionTrackingOnScrollListener thisOSL = from.mOSL;

            if (action == MotionEventActions.Down && to.ScrollState == RecyclerView.ScrollStateIdle)
            {
                mLastY = thisOSL.ScrolledY;

                from.AddOnScrollListener(new CustomScrollListener(to));
            }
            else
            {
                int scrolledY = thisOSL.ScrolledY;

                if (action == MotionEventActions.Up && mLastY == scrolledY)
                    from.ClearOnScrollListeners();
            }
        }

        public override void OnRequestDisallowInterceptTouchEvent(bool disallowIntercept)
        {
        }

        public bool createRelationship(AligningRecyclerViewRelationship aligningRecyclerViewRelationship)
        {
            aligningRecyclerViewRelationships.Add(aligningRecyclerViewRelationship);
            return true;
        }

        public bool destroyRelationship(AligningRecyclerViewRelationship aligningRecyclerViewRelationship)
        {
            aligningRecyclerViewRelationships.Remove(aligningRecyclerViewRelationship);
            return true;
        }

        public bool relationshipExists(AligningRecyclerViewRelationship aligningRecyclerViewRelationship)
        {
            return aligningRecyclerViewRelationships.Contains(aligningRecyclerViewRelationship);
        }
    }
}