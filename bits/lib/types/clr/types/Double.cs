//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.double",true)]
        public readonly struct Double : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Double);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.F64;

            public string Format()
                => Name;
        }
    }
}
