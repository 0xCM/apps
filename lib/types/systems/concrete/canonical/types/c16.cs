//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct c16 : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.C;

            public Identifier Name => nameof(c16);

            public string Format()
                => Name;
        }
    }
}
