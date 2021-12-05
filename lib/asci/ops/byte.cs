//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct Asci
    {
        /// <summary>
        /// Presents the input  as a byte
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in AsciCode src)
            => ref @as<AsciCode,byte>(src);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci2 src)
            => ref @as<asci2,byte>(src);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci4 src)
            => ref @as<asci4,byte>(src);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci8 src)
            => ref @as<asci8,byte>(src);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci16 src)
            => ref @as<asci16,byte>(src);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci32 src)
            => ref @as<asci32,byte>(src);

        /// <summary>
        /// Presents the leading source cell as a byte reference
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ref byte @byte(in asci64 src)
            => ref @as<asci64,byte>(src);
    }
}