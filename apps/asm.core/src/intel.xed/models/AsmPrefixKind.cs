//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Pow2x32;
    using static core;

    using C = AsmPrefixCode;
    using K = AsmPrefixKind;
    using L = AsmPrefixClass;

    public readonly struct AsmPrefixCalcs
    {
        public static AsmPrefixKind kinds(ReadOnlySpan<byte> src)
        {
            var count = src.Length;
            var result = AsmPrefixKind.None;
            for(var i=0; i<count; i++)
            {
                var c = code(skip(src,i));
                if(c != 0)
                    result |= kind(c);
            }
            return result;
        }

        public static AsmPrefixClass @class(AsmPrefixCode src)
            => src switch
            {
                C.Escape => L.Escape,

                C.SsSegOverride => L.Legacy,

                C.EsSegOverride => L.Legacy,

                C.FsSegOverride => L.Legacy,

                C.GsSegOverride => L.Legacy,

                C.OSZ => L.Legacy,

                C.ASZ => L.Legacy,

                C.BranchTaken => L.Legacy,

                C.BranchNotTaken => L.Legacy,

                C.Lock => L.Legacy,

                C.RepF2 => L.Legacy,

                C.RepF3 => L.Legacy,

                C.Rex => L.REX,

                C.VexC4 => L.VEX,

                C.VexC5 => L.VEX,
                _ => L.None,

            };

        public static AsmPrefixClass @class(AsmPrefixKind src)
            => src switch
            {
                K.Escape => L.Escape,

                K.SsSegOverride => L.Legacy,

                K.EsSegOverride => L.Legacy,

                K.FsSegOverride => L.Legacy,

                K.GsSegOverride => L.Legacy,

                K.OSZ => L.Legacy,

                K.ASZ => L.Legacy,

                K.BranchTaken => L.Legacy,

                K.BranchNotTaken => L.Legacy,

                K.Lock => L.Legacy,

                K.RepF2 => L.Legacy,

                K.RepF3 => L.Legacy,

                K.Rex => L.REX,

                K.VexC4 => L.VEX,

                K.VexC5 => L.VEX,
                _ => L.None,
            };

        public static AsmPrefixKind kind(AsmPrefixCode code)
            => code switch
            {
                C.Escape => K.Escape,

                C.SsSegOverride => K.SsSegOverride,

                C.EsSegOverride => K.EsSegOverride,

                C.FsSegOverride => K.FsSegOverride,

                C.GsSegOverride => K.GsSegOverride,

                C.Rex => K.Rex,

                C.OSZ => K.OSZ,

                C.ASZ => K.ASZ,

                C.BranchTaken => K.BranchTaken,

                C.BranchNotTaken => K.BranchNotTaken,

                C.Lock => K.Lock,

                C.RepF2 => K.RepF2,

                C.RepF3 => K.RepF3,

                C.VexC4 => K.VexC4,

                C.VexC5 => K.VexC5,

                _ => K.None,
            };

        public static AsmPrefixCode code(byte src)
            => src switch
            {
                0x0F => C.Escape,

                //0x2E => C.CsSegOverride,
                //0x3E => C.DsSegOverride,

                0x36 => C.SsSegOverride,

                0x26 => C.EsSegOverride,

                0x64 => C.FsSegOverride,

                0x65 => C.GsSegOverride,

                0x40 => C.Rex,

                0x66 => C.OSZ,

                0x67 => C.ASZ,

                0x3E => C.BranchTaken,

                0x2E => C.BranchNotTaken,

                0xF0 => C.Lock,

                0xF2 => C.RepF2,

                0xF3 => C.RepF3,

                0xC4 => C.VexC4,

                0xC5 => C.VexC5,

                _ => C.None,
            };
    }

    [Flags]
    public enum AsmPrefixClass : byte
    {
        None = 0,

        Escape = Pow2x8.P2ᐞ00,

        Legacy = Pow2x8.P2ᐞ01,

        REX = Pow2x8.P2ᐞ02,

        VEX = Pow2x8.P2ᐞ03,

        EVEX = Pow2x8.P2ᐞ04,
    }

    [Flags]
    public enum AsmPrefixKind : uint
    {
        None = 0,

        /// <summary>
        /// Escape prefix
        /// </summary>
        Escape = P2ᐞ00,

        /// <summary>
        /// Lock prefix (Group 1)
        /// </summary>
        Lock = P2ᐞ01,

        /// <summary>
        /// F2 Repeat prefix (Group 1)
        /// </summary>
        RepF2 = P2ᐞ02,

        /// <summary>
        /// F3 Repeat prefix (Group 1)
        /// </summary>
        RepF3 = P2ᐞ03,

        /// <summary>
        /// CS seg override prefix (Group 2)
        /// </summary>
        CsSegOverride = P2ᐞ04,

        /// <summary>
        /// SS seg override prefix (Group 2)
        /// </summary>
        SsSegOverride = P2ᐞ05,

        /// <summary>
        /// DS seg override prefix (Group 2)
        /// </summary>
        DsSegOverride = P2ᐞ06,

        /// <summary>
        /// ES seg override prefix (Group 2)
        /// </summary>
        EsSegOverride = P2ᐞ07,

        /// <summary>
        /// FS seg override prefix (Group 2)
        /// </summary>
        FsSegOverride = P2ᐞ08,

        /// <summary>
        /// GS seg override prefix (Group 2)
        /// </summary>
        GsSegOverride = P2ᐞ09,

        /// <summary>
        /// Branch hint taken (Group 2)
        /// </summary>
        BranchTaken = P2ᐞ10,

        /// <summary>
        /// Branch hint not taken  (Group 2)
        /// </summary>
        BranchNotTaken = P2ᐞ11,

        /// <summary>
        /// Operand size override (Group 3)
        /// </summary>
        OSZ = P2ᐞ12,

        /// <summary>
        /// Address size override (Group 4)
        /// </summary>
        ASZ = P2ᐞ13,

        /// <summary>
        /// Rex prefix
        /// </summary>
        Rex = P2ᐞ20,

        /// <summary>
        /// VEX C4 prefix
        /// </summary>
        VexC4 = P2ᐞ21,

        /// <summary>
        /// VEX C5 prefix
        /// </summary>
        VexC5 = P2ᐞ22,

        /// <summary>
        /// EVEX prefix
        /// </summary>
        Evex = P2ᐞ23,
    }

    /// <summary>
    /// Classifies prefix domains
    /// </summary>
    public enum AsmPrefixCode : byte
    {
        None = 0,

        /// <summary>
        /// Escape prefix
        /// </summary>
        Escape = 0x0F,

        /// <summary>
        /// CS seg override prefix
        /// </summary>
        CsSegOverride = 0x2E,

        /// <summary>
        /// SS seg override prefix
        /// </summary>
        SsSegOverride = 0x36,

        /// <summary>
        /// DS seg override prefix
        /// </summary>
        DsSegOverride = 0x3E,

        /// <summary>
        /// ES seg override prefix
        /// </summary>
        EsSegOverride = 0x26,

        /// <summary>
        /// FS seg override prefix
        /// </summary>
        FsSegOverride = 0x64,

        /// <summary>
        /// GS seg override prefix
        /// </summary>
        GsSegOverride = 0x65,

        /// <summary>
        /// Rex prefix
        /// </summary>
        Rex = 0x40,

        /// <summary>
        /// Operand size override
        /// </summary>
        OSZ = 0x66,

        /// <summary>
        /// Address size override
        /// </summary>
        ASZ = 0x67,

        /// <summary>
        /// Branch hint (taken)
        /// </summary>
        BranchTaken = 0x3E,

        /// <summary>
        /// Branch hint (not taken)
        /// </summary>
        BranchNotTaken = 0x2E,

        /// <summary>
        /// Lock prefix
        /// </summary>
        Lock = 0xF0,

        /// <summary>
        /// Repeat prefix (F2)
        /// </summary>
        RepF2 = 0xF2,

        /// <summary>
        /// Repeat prefix (F3)
        /// </summary>
        RepF3 = 0xF3,

        /// <summary>
        /// VEX C4 prefix
        /// </summary>
        VexC4 = 0xC4,

        /// <summary>
        /// VEX C5 prefix
        /// </summary>
        VexC5 = 0xC5,

        /// <summary>
        /// EVEX prefix
        /// </summary>
        Evex = 0xFF,
    }
}