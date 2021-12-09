//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class dag<L,R> : IDag<L,R>
        where L : ITerm
        where R : ITerm
    {
        public L Left {get;}

        public R Right {get;}

        [MethodImpl(Inline)]
        public dag(L left, R right)
        {
            Left = left;
            Right = right;
        }

        public string Format()
            => LlvmTypes.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator dag<L,R>((L left, R right) src)
            => new dag<L,R>(src.left, src.right);
    }
}