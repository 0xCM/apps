//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct NativeSizes
    {
        [MethodImpl(Inline)]
        public static NativeSegType seg(NativeCellType type, byte count)
            => new NativeSegType(type,count);

        [MethodImpl(Inline)]
        public static NativeSegType seg(NativeClass @class, NativeSizeCode total, NativeSizeCode cell)
        {
            var a = (uint)total;
            var count = ((uint)Sizes.width(total))/((uint)Sizes.width(cell));
            var dst =  (ushort)((uint)cell | ((uint)@class << 4) | (count << 8));
            return @as<ushort,NativeSegType>(dst);
        }

        [MethodImpl(Inline)]
        public static NativeSegType seg(NativeClass @class, ushort total, ushort cell)
            => seg(@class, Sizes.native(total), Sizes.native(cell));

        [MethodImpl(Inline)]
        public static NativeSegType seg(NativeSegKind kind)
            => @as<NativeSegKind,NativeSegType>(kind);
    }
}