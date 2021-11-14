//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm.types
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class dag<T> : IDag<T>
        where T : ITerm
    {
        public T Left {get;}

        public T Right {get;}

        [MethodImpl(Inline)]
        public dag(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsEmpty && Right.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Left.IsNonEmpty && Right.IsNonEmpty;
        }

        public string Format()
        {
            if(Left.IsNonEmpty && Right.IsNonEmpty)
                return string.Format("arrow({0},{1})", Left.Format(), Right.Format());
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
        public static implicit operator dag<T>((T left, T right) src)
            => new dag<T>(src.left, src.right);

        [MethodImpl(Inline)]
        public static implicit operator dag<T>(dag<T,T> src)
            => new dag<T>(src.Left, src.Right);
    }
}