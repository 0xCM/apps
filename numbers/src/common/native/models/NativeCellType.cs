//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct NativeCellType : INativeType<NativeCellType>
    {
        readonly byte Data;

        [MethodImpl(Inline)]
        public NativeCellType(NativeSize size, NativeClass @class)
        {
            Data = (byte)((uint)size.Code | (uint)@class << 4);
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => (NativeSizeCode)(Data & 0xF);
        }

        public NativeClass Class
        {
            [MethodImpl(Inline)]
            get => (NativeClass)(Data >> 4);
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Width;
        }

        public bool IsVoid
        {
            [MethodImpl(Inline)]
            get => Class == NativeClass.None;
        }

        [MethodImpl(Inline)]
        public bool Equals(NativeCellType src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => Data;

        public string Format()
            => NativeTypes.format(this);

        public override string ToString()
            => Format();

        public static NativeCellType Void => default;
    }
}