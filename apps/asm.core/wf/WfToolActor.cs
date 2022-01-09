//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WfToolActor<T> : WfActor<T>, IWfToolActor
        where T : WfToolActor<T>, new()
    {
        protected WfToolActor(string name)
            : base(name)
        {

        }
    }
}