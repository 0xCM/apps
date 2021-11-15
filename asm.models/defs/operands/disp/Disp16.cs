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
    /// Defines a signed 16-bit displacement
    /// </summary>
    public readonly struct Disp16 : IDisplacement<Disp16,short>
    {
        public short Value {get;}

        [MethodImpl(Inline)]
        public Disp16(short value)
        {
            Value = value;
        }

        public byte StorageWidth => 16;

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        int IDisplacement.Value
            => Value;

        public string Format()
            => Value.ToString("x");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Disp16(ushort src)
            => new Disp16((short)src);

        [MethodImpl(Inline)]
        public static implicit operator short(Disp16 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp16(short src)
            => new Disp16(src);

        [MethodImpl(Inline)]
        public static implicit operator ushort(Disp16 src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp16 src)
            => (src.Value,src.StorageWidth);

        [MethodImpl(Inline)]
        public static explicit operator uint(Disp16 src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator int(Disp16 src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(Disp16 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Disp16(ByteSize src)
            => new Disp16((short)src);
    }
}