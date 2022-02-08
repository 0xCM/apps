//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.bool",true)]
        public readonly struct Bool : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Bool);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.U1;

            public string Format()
                => Name;
        }
    }
}
