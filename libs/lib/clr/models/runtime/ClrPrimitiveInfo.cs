//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct ClrPrimitiveInfo : ITextual
    {
        public readonly ClrPrimitiveKind Kind;

        public readonly NativeTypeWidth Width;

        public readonly PolarityKind Sign;

        public readonly PrimalCode TypeCode;

        [MethodImpl(Inline)]
        public ClrPrimitiveInfo(ClrPrimitiveKind kind, NativeTypeWidth width, PolarityKind sign, PrimalCode tc)
        {
            Kind = kind;
            Width = width;
            Sign = sign;
            TypeCode = tc;
        }

        public string Format()
            => Kind.ToString();

        public override string ToString()
            => Format();
    }
}