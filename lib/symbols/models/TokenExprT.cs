//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TokenExpr<T>
        where T : unmanaged, ICharBlock<T>
    {
        public uint Id {get;}

        public T Content {get;}

        public int Length {get;}

        [MethodImpl(Inline)]
        public TokenExpr(uint id, T src)
        {
            Content = src;
            Id = id;
            Length = src.Length;
        }

        public string Format()
            => Content.Format();

        public override string ToString()
            => Format();
    }
}