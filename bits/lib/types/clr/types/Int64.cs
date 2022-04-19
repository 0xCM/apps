//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.i64",true)]
        public readonly struct Int64 : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Int64);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.I64;

            public string Format()
                => Name;
        }
    }
}
