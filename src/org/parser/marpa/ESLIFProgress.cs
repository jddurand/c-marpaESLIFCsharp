namespace org.parser.marpa
{
    public class ESLIFProgress
    {
        public int EarleySetId { get; }
        public int EarleySetOrigId { get; }
        public int Rule { get; }
        public int Position { get; }

        public ESLIFProgress(int earleySetId, int earleySetOrigId, int rule, int position)
        {
            this.EarleySetId = earleySetId;
            this.EarleySetOrigId = earleySetOrigId;
            this.Rule = rule;
            this.Position = position;
        }
    }
}
