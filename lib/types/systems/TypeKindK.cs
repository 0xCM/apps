//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct TypeConstraint
    {
        public TextBlock Expresssion;
    }

    public struct TypeParamDescriptor
    {
        public Identifier Name;

        public Index<TypeConstraint> Constraints;
    }

    public struct TypeDescriptor
    {
        public Identifier Scope;

        public Identifier Name;

        public string Specifier;

        public ClrTypeKind RuntimeKind;

        public TextBlock Description;

        public Index<TypeParamDescriptor> Parameters;

        public bool IsParametric
            => Parameters.IsNonEmpty;
    }

    public readonly struct TypeKind<K> : ITextual
        where K : unmanaged
    {
        readonly K Value {get;}

        [MethodImpl(Inline)]
        public TypeKind(K src)
            => Value = src;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator DataTypeKind(TypeKind<K> src)
            => new DataTypeKind(core.bw64<K>(src.Value));

        [MethodImpl(Inline)]
        public static implicit operator TypeKind<K>(K src)
            => new TypeKind<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator K(TypeKind<K> src)
            => src.Value;
    }
}