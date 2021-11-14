//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.types
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
        {
            if(Left.IsNonEmpty && Right.IsNonEmpty)
                return string.Format("{0} -> {1}", Left.Format(), Right.Format());
            else if(Left.IsEmpty && Right.IsEmpty)
                return EmptyString;
            else if(Left.IsNonEmpty)
                return Left.Format();
            else
                return Right.Format();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator dag<L,R>((L left, R right) src)
            => new dag<L,R>(src.left, src.right);
    }
}