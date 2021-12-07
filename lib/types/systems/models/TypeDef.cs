//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class TypeDef : IType, IEquatable<TypeDef>
    {
        public ulong Kind {get;}

        public TypeDef(ulong kind)
        {
            Kind = 0;
        }

        public virtual string Format()
            => Kind.ToString();

        public sealed override string ToString()
            => Format();

        public bool Equals(TypeDef src)
            => Kind == src.Kind;

        public static TypeDef Empty = new TypeDef(0);
    }
}