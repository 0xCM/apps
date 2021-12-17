//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Canon
    {
        public readonly struct i8 : IScalarType<CanonicalKind>
        {
            public const uint Width = 8;

            public CanonicalKind Kind
                => CanonicalKind.I;

            public Identifier Name
                => nameof(i8);

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

            public static implicit operator ScalarType(i8 src)
                => new ScalarType(src.Name, src.ScalarClass, src.ContentWidth, src.StorageWidth);
        }
    }
}
