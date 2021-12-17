//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Canon
    {
        public readonly struct bits : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.Bits;

            public Identifier Name => nameof(bits);

            public string Format()
                => Name;
        }
    }
}