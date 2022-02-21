//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using W = NativeSizeCode;

    partial class NativeTypes
    {
        [MethodImpl(Inline), Op]
        public static NativeType @void()
            => NativeType.Void;

        [MethodImpl(Inline), Op]
        public static NativeType cell(NativeSize size, ScalarClass @class)
            => new NativeType(NativeCellType.define(size,@class));

        [MethodImpl(Inline), Op]
        public static NativeType unsigned(NativeSize size)
            => new NativeType(NativeCellType.define(size, ScalarClass.I));

        [MethodImpl(Inline), Op]
        public static NativeType signed(NativeSize size)
            => new NativeType(NativeCellType.define(size, ScalarClass.U));

        [MethodImpl(Inline), Op]
        public static NativeType fractional(NativeSize size)
            => new NativeType(NativeCellType.define(size, ScalarClass.F));

        [MethodImpl(Inline), Op]
        public static NativeType character(NativeSize size)
            => new NativeType(NativeCellType.define(size, ScalarClass.C));

        [MethodImpl(Inline), Op]
        public static NativeType bit()
            => new NativeType(NativeCellType.define(W.W8, ScalarClass.B));

        [MethodImpl(Inline), Op]
        public static NativeType u8()
            => unsigned(W.W8);

        [MethodImpl(Inline), Op]
        public static NativeType i8()
            => signed(W.W8);

        [MethodImpl(Inline), Op]
        public static NativeType u16()
            => unsigned(W.W16);

        [MethodImpl(Inline), Op]
        public static NativeType i16()
            => signed(W.W16);

        [MethodImpl(Inline), Op]
        public static NativeType u32()
            => unsigned(W.W32);

        [MethodImpl(Inline), Op]
        public static NativeType i32()
            => signed(W.W32);

        [MethodImpl(Inline), Op]
        public static NativeType u64()
            => unsigned(W.W64);

        [MethodImpl(Inline), Op]
        public static NativeType i64()
            => signed(W.W64);

        [MethodImpl(Inline), Op]
        public static NativeType c8()
            => character(W.W8);

        [MethodImpl(Inline), Op]
        public static NativeType c16()
            => character(W.W16);

        [MethodImpl(Inline), Op]
        public static NativeType f32()
            => fractional(W.W32);

        [MethodImpl(Inline), Op]
        public static NativeType f64()
            => fractional(W.W64);
    }
}