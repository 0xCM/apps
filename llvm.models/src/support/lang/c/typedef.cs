//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.c
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct typedef<T>
    {
        [MethodImpl(Inline)]
        public typedef(T value)
        {
            Value = value;
        }

        public T Value {get;}

        [MethodImpl(Inline)]
        public static implicit operator typedef<T>(T src)
            => new typedef<T>(src);
    }
}