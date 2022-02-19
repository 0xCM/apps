//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeSize
    {
        public readonly NativeSizeCode Code;

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Sizes.width(Code);
        }

        public ByteSize ByteCount
        {
            [MethodImpl(Inline)]
            get => Sizes.bytes(Code);
        }

        [MethodImpl(Inline)]
        public NativeSize(NativeSizeCode kind)
        {
            Code = kind;
        }

        public string Format()
            => Width.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NativeSize(NativeSizeCode src)
            => new NativeSize(src);

        [MethodImpl(Inline)]
        public static implicit operator NativeSizeCode(NativeSize src)
            => (NativeSizeCode)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(NativeSize src)
            => src.Width;

        [MethodImpl(Inline)]
        public static implicit operator ByteSize(NativeSize src)
            => src.ByteCount;

        [MethodImpl(Inline)]
        public static explicit operator ushort(NativeSize src)
            => (ushort)src.Code;
    }
}