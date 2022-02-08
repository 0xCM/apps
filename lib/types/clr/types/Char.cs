//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.char", true)]
        public readonly struct Char : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(Char);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.C16;

            public string Format()
                => Name;
        }
    }
}
