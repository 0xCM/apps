//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline), Op]
        public static ref InstClass value(Field src, out InstClass dst)
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

    }
}