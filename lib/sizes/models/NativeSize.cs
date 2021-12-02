//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType("nsize")]
    public readonly struct NativeSize
    {
        public readonly NativeSizeCode Code;

        [MethodImpl(Inline)]
        public static NativeSizeCode code(BitWidth src)
            => Sizes.native(src);

        [MethodImpl(Inline)]
        public static NativeSize from<W>(W w)
            where W : unmanaged, IDataWidth
                => Sizes.native(w);

        [MethodImpl(Inline)]
        public static NativeSize from(BitWidth src)
            => Sizes.native(src);

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Sizes.width(Code);
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
    }
}