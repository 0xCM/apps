//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        /// <summary>
        /// Determines whether an identified <see cref='ClrPrimitiveKind'/> can be a compile-time literal
        /// </summary>
        /// <param name="src">The kind to test</param>
        [MethodImpl(Inline), Op]
        public static bool literal(ClrPrimitiveKind src)
            => ((byte)src > 2 && (byte)src<16) || (byte)src == 18;
    }
}