//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Actor]
    public abstract class Tool<T> : Actor<T>, ITool<T>
        where T : Tool<T>,new()
    {
        public static T Instance = new T();

        public ToolId ToolId {get;}

        protected Tool(string name)
            : base(name)
        {
            ToolId = name;
        }

        public static implicit operator ToolId(Tool<T> src)
            => src.ToolId;
    }
}
