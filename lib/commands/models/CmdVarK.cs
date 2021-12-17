//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct CmdVar<K>
        where K : unmanaged
    {
        public K Id {get;}

        public string Value;

        [MethodImpl(Inline)]
        public CmdVar(K id)
        {
            Id = id;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdVar(K id, string value)
        {
            Id = id;
            Value = value;
        }

        [MethodImpl(Inline)]
        public CmdVar<K> Set(string value)
        {
            Value = value;
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>(K name)
            => new CmdVar<K>(name);

        [MethodImpl(Inline)]
        public string Format()
            => Value ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>((K id, string value) src)
            => new CmdVar<K>(src.id, src.value);

        [MethodImpl(Inline)]
        public static implicit operator CmdVar<K>(Paired<K,string> src)
            => new CmdVar<K>(src.Left, src.Right);
    }
}