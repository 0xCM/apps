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

        public long Value {get;}

        public NativeSize Size {get;}

        [MethodImpl(Inline)]
        public Disp(long value, NativeSize width)
        {
            Value = value;
            Size = width;
        }

        public AsmOpKind OpKind
        {
            [MethodImpl(Inline)]
            get => AsmOps.kind(AsmOpClass.Disp, Size);
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
        public bool Equals(Disp src)
            => Value == src.Value;

        public string Format()
            => AsmRender.disp(this);

        public override string ToString()
            => Format();

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

        public static Disp Empty => default;

        public static Disp Zero => default;
    }
}