//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct i16 : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.I;

            public Identifier Name => nameof(i16);

            public string Format()
                => Name;
        }
    }
}
