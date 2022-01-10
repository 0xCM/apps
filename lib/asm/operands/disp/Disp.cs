//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Defines an 8, 16, or 32-bit signed displacement
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public readonly struct Disp : IDisplacement
    {
        public long Value {get;}

        public NativeSize Size {get;}

        [MethodImpl(Inline)]
        public Disp(long value, byte width)
        {
            Value = value;
            Size = NativeSize.code(width);
        }

        [MethodImpl(Inline)]
        public Disp(long value, NativeSize width)
        {
            Value = value;
            Size = width;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Disp((int value, byte width) src)
            => new Disp(src.value,src.width);

        [MethodImpl(Inline)]
        public static implicit operator Disp((int value, NativeSize width) src)
            => new Disp(src.value,src.width);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Disp src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(Disp src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator short(Disp src)
            => (short)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Disp src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Disp src)
            => (ulong)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator long(Disp src)
            => src.Value;

        public static Disp Empty => default;

        public static Disp Zero => default;
    }
}