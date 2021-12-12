//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct i8 : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.I;

            public Identifier Name => nameof(i8);

            public string Format()
                => Name;
        }
    }
}
