//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct NativeCellType : INativeType<NativeCellType>
    {
        [MethodImpl(Inline)]
        public static NativeCellType define(NativeSize size, ScalarClass @class)
            => new NativeCellType(size,@class);

        readonly byte Data;

        [MethodImpl(Inline)]
        internal NativeCellType(NativeSize size, ScalarClass @class)
        {
            Data = (byte)((byte)size.Code | (byte)@class << 4);
        }

        public NativeSize Size
        {
            [MethodImpl(Inline)]
            get => (NativeSizeCode)(Data & 0xF);
        }

        public ScalarClass Class
        {
            [MethodImpl(Inline)]
            get => (ScalarClass)(Data >> 4);
        }

        public bool IsVoid
        {
            [MethodImpl(Inline)]
            get => Class == ScalarClass.None;
        }

        [MethodImpl(Inline)]
        public bool Equals(NativeCellType src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => Data;

        public override bool Equals(object src)
            => src is NativeCellType t && Equals(t);

    }
}