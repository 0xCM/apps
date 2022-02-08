//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Pow2x32;

    using static AsmPrefixGroup;

    [Flags,SymSource("asm.encoding")]
    public enum AsmPrefixKind : uint
    {
        None = 0,

        /// <summary>
        /// Lock prefix (Group 1)
        /// </summary>
        [Symbol("LOCK")]
        Lock = P2ᐞ01 | (Group1 << 25),

        /// <summary>
        /// F2 Repeat prefix (Group 1)
        /// </summary>
        [Symbol("REPF2")]
        RepF2 = P2ᐞ02 | (Group1 << 25),

        /// <summary>
        /// F3 Repeat prefix (Group 1)
        /// </summary>
        [Symbol("REPF3")]
        RepF3 = P2ᐞ03 | (Group1 << 25),

        /// <summary>
        /// CS seg override prefix (Group 2)
        /// </summary>
        [Symbol("CS")]
        CsSegOverride = P2ᐞ04 | (Group2 << 25),

        /// <summary>
        /// SS seg override prefix (Group 2)
        /// </summary>
        [Symbol("SS")]
        SsSegOverride = P2ᐞ05 | (Group3 << 25),

        /// <summary>
        /// DS seg override prefix (Group 2)
        /// </summary>
        [Symbol("DS")]
        DsSegOverride = P2ᐞ06 | (Group2 << 25),

        /// <summary>
        /// ES seg override prefix (Group 2)
        /// </summary>
        [Symbol("ES")]
        EsSegOverride = P2ᐞ07 | (Group2 << 25),

        /// <summary>
        /// FS seg override prefix (Group 2)
        /// </summary>
        [Symbol("FS")]
        FsSegOverride = P2ᐞ08 | (Group2 << 25),

        /// <summary>
        /// GS seg override prefix (Group 2)
        /// </summary>
        [Symbol("GS")]
        GsSegOverride = P2ᐞ09 | (Group2 << 25),

        /// <summary>
        /// Branch hint taken (Group 2)
        /// </summary>
        [Symbol("BR1")]
        BranchTaken = P2ᐞ10 | (Group2 << 25),

        /// <summary>
        /// Branch hint not taken  (Group 2)
        /// </summary>
        [Symbol("BR0")]
        BranchNotTaken = P2ᐞ11 | (Group2 << 25),

        /// <summary>
        /// Operand size override (Group 3)
        /// </summary>
        [Symbol("OSZ")]
        OSZ = P2ᐞ12 | (Group3 << 25),

        /// <summary>
        /// Address size override (Group 4)
        /// </summary>
        [Symbol("ASZ")]
        ASZ = P2ᐞ13 | (Group4 << 25),

        /// <summary>
        /// Rex prefix
        /// </summary>
        [Symbol("REX")]
        Rex = P2ᐞ20,

        /// <summary>
        /// VEX C4 prefix
        /// </summary>
        [Symbol("VexC4")]
        VexC4 = P2ᐞ21,

        /// <summary>
        /// VEX C5 prefix
        /// </summary>
        [Symbol("VexC5")]
        VexC5 = P2ᐞ22,

        /// <summary>
        /// EVEX prefix
        /// </summary>
        [Symbol("EVEX")]
        Evex = P2ᐞ23,
    }
}