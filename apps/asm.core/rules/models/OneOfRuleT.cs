//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public class OneOfRule<T> : RuleExpr<Index<T>>
    {

        [MethodImpl(Inline)]
        public OneOfRule(Index<T> src)
            : base(src)
        {

        }

        public override string Format()
            => Content.Delimit(Chars.Pipe, fence:RenderFence.Angled).Format();

        [MethodImpl(Inline)]
        public static implicit operator OneOfRule<T>(T[] src)
            => new OneOfRule<T>(src);
    }
}