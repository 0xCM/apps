//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct Byte : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Byte);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.U8;

            public IParser<byte> ValueParser => Parsers.Service.Parser<byte>();

            public string Format()
                => Name;
        }
    }
}
