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
    /// Defines a signed 32-bit displacement
    /// </summary>
    public readonly struct Disp32 : IDisplacement<Disp32,int>
    {
        public int Value {get;}

        [MethodImpl(Inline)]
        public Disp32(int value)
        {
            Value = value;
        }

        public byte StorageWidth
        {
            [MethodImpl(Inline)]
            get => 32;
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
        public static implicit operator Disp32(uint src)
            => new Disp32((int)src);

        [MethodImpl(Inline)]
        public static implicit operator Disp32(int src)
            => new Disp32(src);

        [MethodImpl(Inline)]
        public static implicit operator uint(Disp32 src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp32 src)
            => new Disp(src.Value, src.StorageWidth);

        [MethodImpl(Inline)]
        public static explicit operator Disp32(long src)
            => new Disp32((int)src);

        public static Disp32 Empty
        {
            [MethodImpl(Inline)]
            get => new Disp32(0);
        }
    }
}