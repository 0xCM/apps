//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct @string : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.S;

            public Identifier Name => nameof(@string);

            public string Format()
                => Name;
        }
    }
}
