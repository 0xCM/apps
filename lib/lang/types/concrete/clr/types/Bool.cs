//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct Bool : IType<ClrPrimitiveKind>
        {
            public IParser<bool> ValueParser => Parsers.Service.Parser<bool>();

            public Identifier Name => nameof(Bool);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.U1;

            public string Format()
                => Name;
        }
    }
}
