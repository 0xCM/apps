//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct TypeDef : ITypeDef, IEquatable<TypeDef>
    {
        public Identifier TypeName {get;}

        public bool IsSized {get;}

        [MethodImpl(Inline)]
        public TypeDef(string name, bool sized)
        {
            TypeName = name;
            IsSized = sized;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => TypeName.IsEmpty;
        }

        public string Format()
            => IsEmpty ? RP.Empty : TypeName;

        public override string ToString()
            => Format();

        public bool Equals(TypeDef src)
            => TypeName.Equals(src.TypeName) && IsSized == src.IsSized;

        public static TypeDef Empty
        {
            [MethodImpl(Inline)]
            get => new TypeDef(EmptyString, false);
        }
    }
}