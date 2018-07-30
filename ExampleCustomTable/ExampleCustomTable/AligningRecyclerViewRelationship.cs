namespace ExampleCustomTable
{
    public class AligningRecyclerViewRelationship
    {
        public AligningRecyclerView rvFrom { get; set; }

        public AligningRecyclerView rvTo { get; set; }

        public AligningRecyclerViewRelationship(AligningRecyclerView from, AligningRecyclerView to)
        {
            this.rvFrom = from;
            this.rvTo = to;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || (this.GetType() != obj.GetType()))
                return false;

            var aligningRecyclerViewRelationship = (AligningRecyclerViewRelationship)obj;

            return rvFrom.Equals(aligningRecyclerViewRelationship.rvFrom) && rvTo.Equals(aligningRecyclerViewRelationship.rvTo);
        }

        public override int GetHashCode()
        {
            int result = rvFrom.GetHashCode();
            result = 31 * result + rvTo.GetHashCode();
            return result;
        }
    }
}
