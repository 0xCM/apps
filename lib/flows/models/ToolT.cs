//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Actor]
    public abstract class Tool<A> : Actor<A>
        where A : Tool<A>,new()
    {
        public static A Instance = new A();

        public ToolId ToolId {get;}

        protected Tool(string name)
            : base(name)
        {
            ToolId = name;
        }

        public static implicit operator ToolId(Tool<A> src)
            => src.ToolId;
    }
}
