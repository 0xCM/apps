//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Flags;

    public struct Flags<T> : IFlags<T>
        where T : unmanaged
    {
        T Data;

        [MethodImpl(Inline)]
        public Flags(T value)
            => Data = value;

        public BitWidth DataWidth
            => core.width<T>();

        public bit this[T flag]
        {
            [MethodImpl(Inline)]
            get => api.state(this, flag);
        }

        public T State
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Flags<T>(T src)
            => new Flags<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Flags<T> src)
            => src.Data;
    }
}
