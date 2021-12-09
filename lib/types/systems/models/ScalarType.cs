//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ScalarType : IScalarType, IEquatable<ScalarType>
    {
        public Identifier Name {get;}

        public ScalarClass Kind {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        [MethodImpl(Inline)]
        public ScalarType(Identifier name, ScalarClass kind, BitWidth content, BitWidth storage)
        {
            Name = name;
            Kind = kind;
            ContentWidth = content;
            StorageWidth = storage;
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

        public bool Equals(ScalarType src)
            => Name.Equals(src.Name) && ContentWidth == src.ContentWidth;

        public static ScalarType Empty
        {
            [MethodImpl(Inline)]
            get => new ScalarType(EmptyString, ScalarClass.None, 0, 0);
        }
    }
}