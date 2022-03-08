//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ClrPrimitiveInfo : ITextual
    {
        public ClrPrimitiveKind Kind {get;}

        public NativeTypeWidth Width {get;}

        public PolarityKind Sign {get;}

        public PrimalCode TypeCode {get;}

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