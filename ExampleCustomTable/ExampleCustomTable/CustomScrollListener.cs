﻿using System;
using Android.Support.V7.Widget;

namespace ExampleCustomTable
{
    public class CustomScrollListener : RecyclerView.OnScrollListener
    {
        private AligningRecyclerView mTo;

        public CustomScrollListener(AligningRecyclerView to)
        {
            this.mTo = to;
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);
            mTo.ScrollBy(0, dy);
        }

        public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
        {
            base.OnScrollStateChanged(recyclerView, newState);
            if (newState == RecyclerView.ScrollStateIdle)
                recyclerView.RemoveOnScrollListener(this);
        }
    }
}