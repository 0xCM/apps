//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct u16 : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.U;

            public Identifier Name => nameof(u16);

            public string Format()
                => Name;
        }
    }
}
