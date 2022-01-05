//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.i32",true)]
        public readonly struct Int32 : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Int32);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.I32;

            public IParser<int> ValueParser => Parsers.Service.Parser<int>();

            public string Format()
                => Name;
        }
    }
}
