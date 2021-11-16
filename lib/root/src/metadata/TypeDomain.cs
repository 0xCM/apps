//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeDomain
    {
        public uint Kind {get;}

        [MethodImpl(Inline)]
        public TypeDomain(uint id)
        {
            Kind = id;
        }

        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeDomain(uint id)
            => new TypeDomain(id);

        [MethodImpl(Inline)]
        public static explicit operator uint(TypeDomain src)
            => src.Kind;
    }
}