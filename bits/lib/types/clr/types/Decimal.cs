//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {

        [DataType("clr.decimal",true)]
        public readonly struct Decimal : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Decimal);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.F128;

            public string Format()
                => Name;
        }
    }
}
