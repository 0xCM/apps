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

    partial struct Hex
    {
        [MethodImpl(Inline)]
        public static ref HexString<K> generic<K>(in HexString<Hex1Seq> src)
            where K : unmanaged
                => ref @as<HexString<Hex1Seq>,HexString<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexString<K> generic<K>(in HexString<Hex2Seq> src)
            where K : unmanaged
                => ref @as<HexString<Hex2Seq>,HexString<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexString<K> generic<K>(in HexString<Hex3Seq> src)
            where K : unmanaged
                => ref @as<HexString<Hex3Seq>,HexString<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexString<K> generic<K>(in HexString<Hex4Seq> src)
            where K : unmanaged
                => ref @as<HexString<Hex4Seq>, HexString<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexStrings<K> generic<K>(in HexStrings<Hex1Seq> src)
            where K : unmanaged
                => ref @as<HexStrings<Hex1Seq>, HexStrings<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexStrings<K> generic<K>(in HexStrings<Hex2Seq> src)
            where K : unmanaged
                => ref @as<HexStrings<Hex2Seq>, HexStrings<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexStrings<K> generic<K>(in HexStrings<Hex3Seq> src)
            where K : unmanaged
                => ref @as<HexStrings<Hex3Seq>, HexStrings<K>>(edit(src));

        [MethodImpl(Inline)]
        public static ref HexStrings<K> generic<K>(in HexStrings<Hex4Seq> src)
            where K : unmanaged
                => ref @as<HexStrings<Hex4Seq>, HexStrings<K>>(edit(src));

    }
}