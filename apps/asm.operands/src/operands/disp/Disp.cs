//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Defines an 8, 16, or 32-bit signed displacement
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct Disp : IDisplacement, IEquatable<Disp>
    {
        [Op]
        public static string format(IDisplacement src)
        {
            var size = src.Size.Code;
            if(size == 0)
                return "0";

            var value = src.Value;

            var dst = RP.Empty;
            switch(size)
            {
                case NativeSizeCode.W8:
                    return ((sbyte)value).FormatHex(zpad:false,specifier:true,uppercase:true);
                case NativeSizeCode.W16:
                    return ((short)value).FormatHex(zpad:false,specifier:true,uppercase:true);
                case NativeSizeCode.W32:
                    return ((int)value).FormatHex(zpad:false,specifier:true,uppercase:true);
                case NativeSizeCode.W64:
                    return ((long)value).FormatHex(zpad:false,specifier:true,uppercase:true);
            }
            return dst;
        }

        public long Value {get;}

        public NativeSize Size {get;}

        [MethodImpl(Inline)]
        public Disp(long value, byte width)
        {
            Value = value;
            Size = Sizes.native(width);
        }

        [MethodImpl(Inline)]
        public Disp(long value, NativeSize width)
        {
            Value = value;
            Size = width;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOperand.kind(AsmOpClass.Disp, Size);
        }

        public AsmOpClass OpClass
            => AsmOpClass.Disp;

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value != 0;
        }

        public bool Positive
        {
            [MethodImpl(Inline)]
            get => Value > 0;
        }

        public bool Negative
        {
            [MethodImpl(Inline)]
            get => Value < 0;
        }

        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        [MethodImpl(Inline)]
        public bool Equals(Disp src)
            => Value == src.Value;

        public string Format()
            => format(this);

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

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp src)
            => new AsmOperand(src);

        public static Disp Empty => default;

        public static Disp Zero => default;
    }
}