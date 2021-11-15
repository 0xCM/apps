//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class Box<T> : StrongBox<T>
        where T : struct
    {
        [MethodImpl(Inline)]
        public Box(T src)
        {
            Value = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator Box<T>(T src)
            => new Box<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator T(Box<T> src)
            => src.Value;
    }
}