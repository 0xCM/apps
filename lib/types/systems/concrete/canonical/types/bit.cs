//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Canon
    {
        public readonly struct bit : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.Bit;

            public Identifier Name => nameof(bit);

            public string Format()
                => Name;
        }
    }
}