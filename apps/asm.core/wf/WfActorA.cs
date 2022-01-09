//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [WfActor]
    public abstract class WfActor : IActor
    {
        public Identifier Name {get;}

        protected WfActor(Identifier name)
        {
            Name = name;
        }
    }

    public abstract class WfActor<A> : WfActor, IActor<A>
        where A : WfActor<A>, new()
    {
        public static A Instance = new();

        protected WfActor(Identifier name)
            : base(name)
        {
        }
    }
}