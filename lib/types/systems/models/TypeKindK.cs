//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeKind<K> : ITypeKind<K>
        where K : unmanaged
    {
        public K Key {get;}

        public Identifier Name {get;}

        [MethodImpl(Inline)]
        public TypeKind(K src, Identifier name)
        {
            Key = src;
            Name = name;
        }

        public Identifier Class
        {
            [MethodImpl(Inline)]
            get => typeof(K).Name;
        }

        public string Format()
            => string.Format("{0}:{1}",Name, Class);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeKind(TypeKind<K> src)
            => new TypeKind(core.bw64<K>(src.Key), src.Class, src.Name);
    }
}