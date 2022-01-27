//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public class SplitRule<T> : Rule
    {
        public T Source {get;}

        public Index<T> Target {get;}
        public override string Format()
            => string.Format("{0} -> {1}", Source, Target.Delimit(Chars.Comma, fence:RenderFence.Paren).Format());
    }
}