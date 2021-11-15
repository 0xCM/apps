//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AddressBankIndex : ITextual
    {
        public ushort Selector {get;}

        public ushort Base {get;}

        [MethodImpl(Inline)]
        public AddressBankIndex(ushort selector, ushort @base)
        {
            Selector = selector;
            Base = @base;
        }

        public string Format()
            => string.Format("{0:D3}:{1:D5}", Selector, Base);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AddressBankIndex((ushort s, ushort b) src)
            => new AddressBankIndex(src.s,src.b);
    }
}