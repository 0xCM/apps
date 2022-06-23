//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.u8",true)]
        public readonly struct Byte : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Byte);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.U8;

            public string Format()
                => Name;
        }
    }
}