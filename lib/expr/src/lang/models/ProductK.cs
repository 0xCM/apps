//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Product<K>
    {
        public K Left {get;}

        public K Right {get;}

        [MethodImpl(Inline)]
        public Product(K left, K right)
        {
            Left = left;
            Right = right;
        }

        public string Format()
            => string.Format("{0}{1}", Left, Right);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Product<K>((K left, K right) src)
            => new Product<K>(src.left,src.right);
    }
}