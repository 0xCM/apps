//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Sop<K>
    {
        public Product<K> Left {get;}

        public Product<K> Right {get;}

        [MethodImpl(Inline)]
        public Sop(Product<K> left, Product<K> right)
        {
            Left = left;
            Right = right;
        }

        public string Format()
            => string.Format("({0}|{1})", Left, Right);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Sop<K>((Product<K> left, Product<K> right) src)
            => new Sop<K>(src.left,src.right);
    }
}