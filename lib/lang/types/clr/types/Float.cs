//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.float",true)]
        public readonly struct Float : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Float);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.F32;

            public string Format()
                => Name;
        }
    }
}
