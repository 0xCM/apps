//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Canon
    {
        public readonly struct u32 : IScalarType<CanonicalKind>
        {
            public const uint Width = 32;

            public CanonicalKind Kind
                => CanonicalKind.U;

            public Identifier Name
                => nameof(u32);

            public ScalarClass ScalarClass
                => ScalarClass.U;

            public BitWidth ContentWidth
                => Width;

            public BitWidth StorageWidth
                => Width;

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            public static implicit operator ScalarType(u32 src)
                => new ScalarType(src.Name, src.ScalarClass, src.ContentWidth, src.StorageWidth);
        }
    }
}