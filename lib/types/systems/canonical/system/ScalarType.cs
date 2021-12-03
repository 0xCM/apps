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

        [MethodImpl(Inline)]
        public ScalarType(Identifier name, ScalarClass @class, BitWidth content, BitWidth storage)
        {
            TypeName = name;
            Class = @class;
            ContentWidth = content;
            StorageWidth = storage;
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

        public static TypeDef Empty
        {
            [MethodImpl(Inline)]
            get => new TypeDef(EmptyString, false);
        }
    }
}