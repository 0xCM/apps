//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Canon
    {
        public readonly struct i64 : IScalarType<CanonicalKind>
        {
            public const uint Width = 64;

            public CanonicalKind Kind
                => CanonicalKind.I;

            public Identifier Name
                => nameof(i64);

            public ScalarClass ScalarClass
                => ScalarClass.I;

            public BitWidth ContentWidth
                => Width;

            public BitWidth StorageWidth
                => Width;

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            public static implicit operator ScalarType(i64 src)
                => new ScalarType(src.Name, src.ScalarClass, src.ContentWidth, src.StorageWidth);
        }
    }
}