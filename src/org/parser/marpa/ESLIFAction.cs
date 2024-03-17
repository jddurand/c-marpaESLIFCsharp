namespace org.parser.marpa
{
    public class ESLIFAction
    {
        public ESLIFActionType actionType { get; }
        public string name { get; }
        public string @string { get; }
        public string lua {  get; }
        public ESLIFLuaFunction luaFunction { get; }

        public ESLIFAction(ESLIFActionType actionType, string name, string @string, string lua, ESLIFLuaFunction luaFunction)
        {
            this.actionType = actionType;
            this.name = name;
            this.@string = @string;
            this.lua = lua;
            this.luaFunction = luaFunction;
        }

        public override string ToString()
        {
            switch (this.actionType)
            {
                case ESLIFActionType.NAME:
                    return $"ESLIFAction [actionType={this.actionType}, name={this.name}]";
                case ESLIFActionType.STRING:
                    return $"ESLIFAction [actionType={this.actionType}, name={this.@string}]";
                case ESLIFActionType.LUA:
                    return $"ESLIFAction [actionType={this.actionType}, name={this.lua}]";
                case ESLIFActionType.LUAFUNCTION:
                    return $"ESLIFAction [actionType={this.actionType}, name={this.luaFunction}]";
                default:
                    return "ESLIFAction [actionType=???]";
            }
        }
    }
}