//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Actor : IActor
    {
        public Name Name {get;}

        protected Actor(Name name)
        {
            Name = name;
        }

        public virtual string Format()
            => Name;

        public override sealed string ToString()
            => Format();
    }
}