//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.u32",true)]
        public readonly struct UInt32 : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(UInt32);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.U32;

            public string Format()
                => Name;
        }
    }
}
