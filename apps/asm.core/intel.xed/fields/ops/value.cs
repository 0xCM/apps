//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static ref ChipCode value(Field src, out ChipCode dst)
        {
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref InstClass value(Field src, out InstClass dst)
        {
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref BCastKind value(Field src, out BCastKind dst)
        {
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref Register value(Field src, out Register dst)
        {
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref bit value(Field src, out bit dst)
        {
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref byte value(Field src, out byte dst)
        {
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref ushort value(Field src, out ushort dst)
        {
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref uint value(Field src, out uint dst)
        {
            dst = src;
            return ref dst;
        }
    }
}