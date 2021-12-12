//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct u64 : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.U;

            public Identifier Name => nameof(u64);

            public string Format()
                => Name;
        }
    }
}
