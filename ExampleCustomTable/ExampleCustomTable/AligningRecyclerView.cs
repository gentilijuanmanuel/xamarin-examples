using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;

namespace ExampleCustomTable
{
    [Register("exampleCustomTable.AligningRecyclerView")]
    public class AligningRecyclerView : RecyclerView
    {
        private OnScrollListenerManagerOnItemTouchListener mOSLManager { get; set; }
        public PositionTrackingOnScrollListener mOSL;

        public AligningRecyclerView(Context context) : base(context)
        {
            InitializeProperties();
        }

        public AligningRecyclerView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            InitializeProperties();
        }

        private void InitializeProperties()
        {
            this.mOSL = new PositionTrackingOnScrollListener();
            this.AddOnScrollListener(this.mOSL);
            this.mOSLManager = new OnScrollListenerManagerOnItemTouchListener();
            this.AddOnItemTouchListener(this.mOSLManager);
        }

        public bool bindTo(AligningRecyclerView target)
        {
            return !isBound(target) && mOSLManager.createRelationship(new AligningRecyclerViewRelationship(this, target));
        }

        public bool isBound(AligningRecyclerView target)
        {
            return mOSLManager.relationshipExists(new AligningRecyclerViewRelationship(this, target));
        }
    }
}
