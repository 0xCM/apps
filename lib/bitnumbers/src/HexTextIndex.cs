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

    using H = Hex3;
    using N = N3;

    [ApiHost]
    public readonly struct HexTextIndex
    {
        [MethodImpl(Inline)]
        public static HexIndex<K> index<K>(K[] src)
            where K : unmanaged, IHexNumber
                => new HexIndex<K>(src);

        [MethodImpl(Inline), Op]
        public static HexIndex<H> init(N n, byte[] src)
            => index<H>(@as<byte[],H[]>(src));

        [MethodImpl(Inline)]
        public static HexStrings<K> init<K>()
            where K : unmanaged, Enum
        {
            if(typeof(K) == typeof(Hex1Seq))
                return Hex.generic<K>(init(n1));
            else if(typeof(K) == typeof(Hex2Seq))
                return Hex.generic<K>(init(n2));
            else if(typeof(K) == typeof(Hex3Seq))
                return Hex.generic<K>(init(n3));
            else if(typeof(K) == typeof(Hex4Seq))
                return Hex.generic<K>(init(n4));
            else
                return HexStrings<K>.Empty;
        }

        [MethodImpl(Inline)]
        static HexString<K> hs<K>(string src)
            where K : unmanaged, Enum
                => new HexString<K>(src);

        [MethodImpl(Inline), Op]
        public static HexStrings<Hex1Seq> init(N1 n)
            => new HexStrings<Hex1Seq>(sys.array(
                    hs<Hex1Seq>(Hex1Text.x00),
                    hs<Hex1Seq>(Hex1Text.x01))
                    );

        [MethodImpl(Inline), Op]
        public static HexStrings<Hex2Seq> init(N2 n)
            => new HexStrings<Hex2Seq>(sys.array(
                hs<Hex2Seq>(Hex2Text.x00),
                hs<Hex2Seq>(Hex2Text.x01),
                hs<Hex2Seq>(Hex2Text.x02),
                hs<Hex2Seq>(Hex2Text.x03)
                ));

        [Op]
        public static HexStrings<Hex3Seq> init(N3 n)
            => new HexStrings<Hex3Seq>(sys.array(
                    hs<Hex3Seq>(Hex3Text.x00),
                    hs<Hex3Seq>(Hex3Text.x01),
                    hs<Hex3Seq>(Hex3Text.x02),
                    hs<Hex3Seq>(Hex3Text.x03),
                    hs<Hex3Seq>(Hex3Text.x04),
                    hs<Hex3Seq>(Hex3Text.x05),
                    hs<Hex3Seq>(Hex3Text.x06),
                    hs<Hex3Seq>(Hex3Text.x07)
                        ));

        [Op]
        public static HexStrings<Hex4Seq> init(N4 n)
            => new HexStrings<Hex4Seq>(sys.array(
                    hs<Hex4Seq>(Hex4Text.x00),
                    hs<Hex4Seq>(Hex4Text.x01),
                    hs<Hex4Seq>(Hex4Text.x02),
                    hs<Hex4Seq>(Hex4Text.x03),
                    hs<Hex4Seq>(Hex4Text.x04),
                    hs<Hex4Seq>(Hex4Text.x05),
                    hs<Hex4Seq>(Hex4Text.x06),
                    hs<Hex4Seq>(Hex4Text.x07),
                    hs<Hex4Seq>(Hex4Text.x08),
                    hs<Hex4Seq>(Hex4Text.x09),
                    hs<Hex4Seq>(Hex4Text.x0A),
                    hs<Hex4Seq>(Hex4Text.x0B),
                    hs<Hex4Seq>(Hex4Text.x0C),
                    hs<Hex4Seq>(Hex4Text.x0D),
                    hs<Hex4Seq>(Hex4Text.x0E),
                    hs<Hex4Seq>(Hex4Text.x0F)
                    ));
    }
}