//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PrimalClass
    {
        public readonly ClrPrimitiveKind Kind;

        public PrimalClass(ClrPrimitiveKind kind)
        {
            Kind = kind;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Kind;
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