namespace org.parser.marpa
{
    public class ESLIFProgress
    {
        public int earleySetId { get; }
        int earleySetOrigId { get; }
        int rule { get; }
        int position { get; }

        public ESLIFProgress(int earleySetId, int earleySetOrigId, int rule, int position)
        {
            this.earleySetId = earleySetId;
            this.earleySetOrigId = earleySetOrigId;
            this.rule = rule;
            this.position = position;
        }

        public override string ToString()
        {
            return "ESLIFProgress ["
                + $"earleySetId={earleySetId}, "
                + $"earleySetOrigId={earleySetOrigId}, "
                + $"rule={rule}, "
                + $"position={position}"
                + "]";
        }
    }
}
