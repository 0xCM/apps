//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Actor : IActor
    {
        public Name Name {get;}

        public abstract IType SourceType {get;}

        public abstract IType TargetType {get;}

        protected Actor(Name name)
        {
            Name = name;
        }

        public virtual string Format()
            => string.Format("{0}:{1} -> {2}", Name, SourceType.Name, TargetType.Name);

        public override sealed string ToString()
            => Format();
    }
}