//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct u32 : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.U;

            public Identifier Name => nameof(u32);

            public string Format()
                => Name;
        }
    }
}
