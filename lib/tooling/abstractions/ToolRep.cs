//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ToolRep<T> : WfActor<T>, IToolRep
        where T : ToolRep<T>, new()
    {
        protected ToolRep(string name)
            : base(name)
        {

        }
    }
}