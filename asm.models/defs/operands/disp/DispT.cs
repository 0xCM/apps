//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a parametric displacement that may resolve to an 8-bit, 16-bit or 32-bit signed displacement
    /// </summary>
    public readonly struct Disp<T> : IDisplacement
        where T : unmanaged, IDisplacement<T>
    {
        public T Source {get;}

        [MethodImpl(Inline)]
        public Disp(T src)
        {
            Source = src;
        }

        public int Value
        {
            [MethodImpl(Inline)]
            get => int32(Source.Value);
        }

        public byte StorageWidth
        {
            [MethodImpl(Inline)]
            get => Source.StorageWidth;
        }

        public string Format()
            => Value.ToString("x");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(byte src)
            => new Disp<T>(@as<byte,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(Disp8 src)
            => new Disp<T>(@as<sbyte,T>(src.Value));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(short src)
            => new Disp<T>(@as<short,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(Disp16 src)
            => new Disp<T>(@as<short,T>(src.Value));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(int src)
            => new Disp<T>(@as<int,T>(src));

        [MethodImpl(Inline)]
        public static implicit operator Disp<T>(Disp32 src)
            => new Disp<T>(@as<int,T>(src.Value));

        [MethodImpl(Inline)]
        public static implicit operator T(Disp<T> src)
            => src.Source;
    }
}