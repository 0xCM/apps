//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Actor]
    public abstract class Tool<T> : Service<T>
        where T : Tool<T>,new()
    {
        public ToolId Id {get;}

        protected Tool(ToolId id)
        {
            Id = id;
        }
    }
}
