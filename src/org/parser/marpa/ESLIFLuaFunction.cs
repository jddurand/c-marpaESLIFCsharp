namespace org.parser.marpa
{
    public class ESLIFLuaFunction
    {
        public string luas { get; }
        public string actions { get; }
        public short luacb { get; }
        public byte[] luacp { get; }
        public byte[] luacstrip { get; }

        public ESLIFLuaFunction(string luas, string actions, short luacb, byte[] luacp, byte[] luacstrip)
        {
            this.luas = luas;
            this.actions = actions;
            this.luacb = luacb;
            this.luacp = luacp;
            this.luacstrip = luacstrip;
        }

        public override string ToString()
        {
            return
                $"ESLIFLuaFunction [luas={luas}" +
                $", actions={actions}" +
                $", luacb={luacb}" + "]";
        }
    }
}
