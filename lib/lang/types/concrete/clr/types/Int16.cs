//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct Int16 : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Int16);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.I16;

            public IParser<short> ValueParser => Parsers.Service.Parser<short>();

            public string Format()
                => Name;
        }
    }
}
