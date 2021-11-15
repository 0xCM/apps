//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ResourceName : ITextual
    {
        readonly string Value;

        [MethodImpl(Inline)]
        public ResourceName(string src)
            => Value = src;

        [MethodImpl(Inline)]
        public string Format()
            => Value;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ResourceName(string src)
            => new ResourceName(src);

        [MethodImpl(Inline)]
        public static implicit operator string(ResourceName src)
            => src.Value ?? EmptyString;
    }
}