//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct CmdVar<K,T>
        where K : unmanaged
    {
        public K Id {get;}

        public T Value;

        [MethodImpl(Inline)]
        public CmdVar(K id)
        {
            Id = id;
            Value = default;
        }

        [MethodImpl(Inline)]
        public CmdVar(K id, T value)
        {
            Id = id;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdVar<K,T> Set(T value)
        {
            Value = value;
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K,T>(K name)
            => new CmdVar<K,T>(name);

        [MethodImpl(Inline)]
        public string Format()
            => Value?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K,T>((K id, T value) src)
            => new CmdVar<K,T>(src.id, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K,T>(Paired<K,T> src)
            => new CmdVar<K,T>(src.Left, src.Right);
    }
}