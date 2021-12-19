//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Actor : IActor
    {
        public Identifier Name {get;}

        protected Actor(Identifier name)
        {
            Name = name;
        }


        public virtual string Format()
            => Name;

        public override sealed string ToString()
            => Format();
    }
}