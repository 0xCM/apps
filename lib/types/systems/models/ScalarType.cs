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
        public Identifier TypeName {get;}

        public ScalarClass Class {get;}

        public BitWidth ContentWidth {get;}

        public BitWidth StorageWidth {get;}

        public TypeKind Kind {get;}

        [MethodImpl(Inline)]
        public ScalarType(Identifier name, ScalarClass @class, BitWidth content, BitWidth storage)
        {
            TypeName = name;
            Class = @class;
            ContentWidth = content;
            StorageWidth = storage;
            Kind = new TypeKind(0, Class.ToString(), name,0);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => TypeName.IsEmpty;
        }

        public virtual string Format()
            => IsEmpty ? RP.Empty : TypeName;

        public override string ToString()
            => Format();

        public bool Equals(ScalarType src)
            => TypeName.Equals(src.TypeName) && ContentWidth == src.ContentWidth;

        public static ScalarType Empty
        {
            [MethodImpl(Inline)]
            get => new ScalarType(EmptyString, ScalarClass.None, 0, 0);
        }
    }
}