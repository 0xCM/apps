//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines an 8, 16, or 32-bit signed displacement
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct Disp : IDisplacement, IEquatable<Disp>
    {
        public static string format<T>(T src, bool @signop = false)
            where T : IDisplacement
        {
            var dst = text.buffer();
            var value = src.Value;
            if(src.Negative)
            {
                if(@signop)
                {
                    dst.Append(Chars.Dash);
                    dst.Append(Chars.Space);
                }
                else
                    dst.Append(Chars.Dash);

                switch(src.Size.Code)
                {
                    case NativeSizeCode.W8:
                        dst.Append(((byte)((~((byte)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W16:
                        dst.Append(((ushort)((~((ushort)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W32:
                        dst.Append(((uint)((~((uint)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W64:
                        dst.Append(((ulong)((~((ulong)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    break;
                    default:
                        dst.Append(string.Format("error<{0}>", src.Size.Code));
                    break;
                }
            }
            else
            {
                if(@signop)
                {
                    dst.Append(Chars.Plus);
                    dst.Append(Chars.Space);
                }

                switch(src.Size.Code)
                {
                    case NativeSizeCode.W8:
                        dst.Append(((byte)value).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W16:
                        dst.Append(((ushort)value).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W32:
                        dst.Append(((uint)value).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W64:
                        dst.Append(((long)value).FormatHex(zpad:false, uppercase:true));
                    break;
                    default:
                        dst.Append(string.Format("error<{0}>", src.Size.Code));
                    break;
                }
            }
            return dst.Emit();
        }

        [Parser]
        public static Outcome parse(string src, NativeSize size, out Disp dst)
        {
            var result = Outcome.Success;
            dst = Empty;
            switch(size.Code)
            {
                case NativeSizeCode.W64:
                {
                    result = Disp64.parse(src, out var _dst);
                    if(result)
                        dst = new Disp(_dst, size);
                }
                break;
                case NativeSizeCode.W32:
                {
                    result = Disp32.parse(src, out var _dst);
                    if(result)
                        dst = new Disp(_dst, size);
                }
                break;
                case NativeSizeCode.W16:
                {
                    result = Disp16.parse(src, out var _dst);
                    if(result)
                        dst = new Disp(_dst, size);
                }
                break;
                case NativeSizeCode.W8:
                {
                    result = Disp8.parse(src, out var _dst);
                    if(result)
                        dst = new Disp(_dst, size);
                }
                break;
                default:
                    result = false;
                break;
            }

            return result;
        }

        public readonly long Value;

        public readonly NativeSize Size;

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
        public bool Equals(Disp src)
            => Value == src.Value;

        public string Format()
            => Disp.format(this);

        public override string ToString()
            => Format();

        NativeSize IDisplacement.Size
            => Size;

        long IDisplacement.Value
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp((long value, NativeSize width) src)
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
        public static explicit operator Disp(ulong src)
            => new Disp((long)src, NativeSizeCode.W64);

        [MethodImpl(Inline)]
        public static explicit operator Disp(long src)
            => new Disp(src, NativeSizeCode.W64);

        [MethodImpl(Inline)]
        public static explicit operator Disp(int src)
            => new Disp(src, NativeSizeCode.W32);

        [MethodImpl(Inline)]
        public static explicit operator Disp(uint src)
            => new Disp(src, NativeSizeCode.W32);

        [MethodImpl(Inline)]
        public static explicit operator Disp(short src)
            => new Disp(src, NativeSizeCode.W16);

        [MethodImpl(Inline)]
        public static explicit operator Disp(ushort src)
            => new Disp(src, NativeSizeCode.W16);

        [MethodImpl(Inline)]
        public static explicit operator Disp(byte src)
            => new Disp(src, NativeSizeCode.W8);

        [MethodImpl(Inline)]
        public static explicit operator Disp(sbyte src)
            => new Disp(src, NativeSizeCode.W8);

        public static Disp Empty => default;

        public static Disp Zero => default;

    }
}