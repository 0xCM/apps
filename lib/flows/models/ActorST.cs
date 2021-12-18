//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Actor<S,T> : Actor, IActor<S,T>
        where S : IType
        where T : IType
    {
        protected Actor(Name name)
            : base(name)
        {

        }

        public abstract S Source {get;}

        public abstract T Target {get;}

        public override sealed IType SourceType
            => Source;

        public override sealed IType TargetType
            => Target;
    }
}