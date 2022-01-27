//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class Rule : IRule
    {
        public abstract string Format();

        public override string ToString()
            => Format();

        public virtual bool IsTerminal => false;
    }
}