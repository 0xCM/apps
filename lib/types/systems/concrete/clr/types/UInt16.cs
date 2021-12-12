//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct UInt16 : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(UInt16);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.U16;

            public string Format()
                => Name;
        }
    }
}
