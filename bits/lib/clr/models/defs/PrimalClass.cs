//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct PrimalClass
    {
        public ClrPrimitiveKind Kind {get;}

        public PrimalClass(ClrPrimitiveKind kind)
        {
            Kind = kind;
        }

        public string Format()
            => Kind.ToString().ToLower();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PrimalClass(ClrPrimitiveKind src)
            => new PrimalClass(src);

        [MethodImpl(Inline)]
        public static implicit operator ClrPrimitiveKind(PrimalClass src)
            => src.Kind;
    }
}