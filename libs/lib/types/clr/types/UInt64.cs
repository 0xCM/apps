//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.u64",true)]
        public readonly struct UInt64 : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(UInt64);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.U64;

            public string Format()
                => Name;
        }
    }
}
