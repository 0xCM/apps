//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ScalarType<K> : IScalarType<K>, IEquatable<ScalarType<K>>
        where K : unmanaged, ISizedType, IEquatable<K>
    {
        public Identifier Name {get;}

        public K Kind {get;}

        public ScalarClass ScalarClass {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        [MethodImpl(Inline)]
        public ScalarType(Identifier name, ScalarClass @class, K kind)
        {
            Name = name;
            Kind = kind;

            ContentWidth = kind.ContentWidth;
            StorageWidth = kind.StorageWidth;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public virtual string Format()
            => IsEmpty ? RP.Empty : Name;

        public override string ToString()
            => Format();

        public bool Equals(ScalarType<K> src)
            => Name.Equals(src.Name) && ContentWidth == src.ContentWidth && Kind.Equals(src.Kind);

        [MethodImpl(Inline)]
        public static implicit operator ScalarType(ScalarType<K> src)
            => new ScalarType(src.Name, src.ScalarClass, src.ContentWidth, src.StorageWidth);

        public static ScalarType Empty
        {
            [MethodImpl(Inline)]
            get => new ScalarType(EmptyString, ScalarClass.None, 0, 0);
        }
    }
}