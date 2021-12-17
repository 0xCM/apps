//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        public readonly struct SByte : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(SByte);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.I8;

            public string Format()
                => Name;
        }
    }
}
