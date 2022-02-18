//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmPrefixCodes;


    [ApiHost]
    public readonly struct AsmPrefix
    {
        public static SizeOverride opsz()
            => SizeOverrideCode.OPSZ;

        public static SizeOverride adsz()
            => SizeOverrideCode.ADSZ;
    }
}