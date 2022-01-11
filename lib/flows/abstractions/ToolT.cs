//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Tool<T> : Actor<T>, ITool
        where T : Tool<T>, new()
    {
        protected Tool(string name)
            : base(name)
        {
            ToolId = name;
        }

        public ToolId ToolId {get;}


        public static implicit operator ToolId(Tool<T> src)
            => src.ToolId;
    }
}