namespace org.parser.marpa
{
    public class ESLIFAction
    {
        public ESLIFActionType actionType { get; }
        public string name { get; }
        public string lua {  get; }
        public ESLIFLuaFunction luaFunction { get; }

        public ESLIFAction(ESLIFActionType actionType, string name, string lua, ESLIFLuaFunction luaFunction)
        {
            this.actionType = actionType;
            this.name = name;
            this.lua = lua;
            this.luaFunction = luaFunction;
        }
    }
}