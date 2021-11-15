//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct Sequential<T>
        where T : unmanaged
    {
        const long Step = 1;

        internal T Lo;

        internal T Hi;

        [MethodImpl(Inline)]
        public Sequential(T src)
        {
            Lo = src;
            Hi = default;
        }

        [MethodImpl(Inline)]
        public Sequential(T src, T hi)
        {
            Lo = src;
            Hi = hi;
        }

        public Sequential<T> Next()
            => seq.next(this);

        public void IncLo()
        {
            ref var x = ref @as<T,long>(Lo);
            x += Step;
        }

        public void IncHi()
        {
            ref var x = ref @as<T,long>(Hi);
            x += Step;
        }

        public void DecLo()
        {
            ref var x = ref @as<T,long>(Lo);
            x -= Step;
        }

        public void DecHi()
        {
            ref var x = ref @as<T,long>(Hi);
            x -= Step;
        }

        public string Format()
            => EmptyString;

        [MethodImpl(Inline)]
        public static Sequential<T> operator ++(Sequential<T> src)
        {
            src.IncLo();
            return src;
        }

        [MethodImpl(Inline)]
        public static Sequential<T> operator --(Sequential<T> src)
        {
            src.DecLo();
            return src;
        }

        [MethodImpl(Inline)]
        public static implicit operator Sequential<T>(T src)
            => new Sequential<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Sequential<T> src)
            => src.Lo;
    }
}