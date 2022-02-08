//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.i16",true)]
        public readonly struct Int16 : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Int16);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.I16;

            public string Format()
                => Name;
        }
    }
}
