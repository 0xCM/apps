//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CanonicalTypes
    {
        public readonly struct i32 : IType<CanonicalKind>
        {
            public CanonicalKind Kind => CanonicalKind.I;

            public Identifier Name => nameof(i32);

            public string Format()
                => Name;
        }
    }
}
