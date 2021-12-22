//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a signed 64-bit displacement
    /// </summary>
    public readonly struct Disp64 : IDisplacement<Disp64,long>
    {
        public long Value {get;}

        [MethodImpl(Inline)]
        public Disp64(long value)
        {
            Value = value;
        }

        public byte StorageWidth
        {
            [MethodImpl(Inline)]
            get => 64;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public string Format()
            => Value.ToString("x");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ulong(Disp64 src)
            => (ulong)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator long(Disp64 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp64 src)
            => new Disp(src.Value, src.StorageWidth);

        [MethodImpl(Inline)]
        public static implicit operator Disp64(ulong src)
            => new Disp64((long)src);

        [MethodImpl(Inline)]
        public static implicit operator Disp64(long src)
            => new Disp64((int)src);

        public static Disp64 Empty
        {
            [MethodImpl(Inline)]
            get => new Disp64(0);
        }
    }
}