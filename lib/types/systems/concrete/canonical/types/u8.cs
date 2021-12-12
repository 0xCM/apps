//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct u8 : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.U;

            public Identifier Name => nameof(u8);

            public string Format()
                => Name;
        }
    }
}
