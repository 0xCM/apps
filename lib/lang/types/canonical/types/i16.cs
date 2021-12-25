//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Canon
    {
        public readonly struct i16 : IScalarType<CanonicalKind>
        {
            public const uint Width = 16;

            public CanonicalKind Kind
                => CanonicalKind.I;

            public Identifier Name
                => nameof(i16);

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

            public static implicit operator ScalarType(i16 src)
                => new ScalarType(src.Name, src.ScalarClass, src.ContentWidth, src.StorageWidth);
        }
    }
}