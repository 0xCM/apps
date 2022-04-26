//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using T = XedRules.FieldDataKind;

    partial class XedDb
    {
        public enum DomainType
        {
            [Symbol("")]
            None,

            [Symbol("bit")]
            Bit = T.Bit,

            [Symbol("byte")]
            Byte = T.Byte,

            [Symbol("ushort")]
            Word = T.Word,

            [Symbol("XedRegId")]
            Reg = T.Reg,

            [Symbol("CHIP")]
            Chip = T.Chip,

            [Symbol("ICLASS")]
            InstClass = T.InstClass,

            [Symbol("uint1")]
            U1,

            [Symbol("uint2")]
            U2,

            [Symbol("uint3")]
            U3,

            [Symbol("uint4")]
            U4,

            [Symbol("uint5")]
            U5,

            [Symbol("hex4")]
            Hex4,

            [Symbol("hex8")]
            Hex8,

            [Symbol("hex16")]
            Hex16,

            [Symbol("BCAST")]
            BCastKind,

            [Symbol("BRDISP_WIDTH")]
            BrDispWidth,

            [Symbol("ERROR")]
            Error,

            [Symbol("EASZ")]
            EASZ,

            [Symbol("EOSZ")]
            EOSZ,

            [Symbol("ERSC")]
            ESRC,

            [Symbol("HINT")]
            HintKind,

            [Symbol("LLRC")]
            LLRC,

            [Symbol("MODE")]
            MachineMode,

            [Symbol("MASK")]
            MaskReg,

            [Symbol("VEXVALID")]
            VexClass,

            [Symbol("VEX_PREFIX")]
            VexKind,

            [Symbol("VL")]
            VexLength,

            [Symbol("SMODE")]
            SMode,

            [Symbol("ROUNDC")]
            RoundingKind,

            [Symbol("SEG_OVD")]
            SegPrefixKind,

            [Symbol("SCALE")]
            MemoryScale,

            [Symbol("NativeSize")]
            NativeSize,

            [Symbol("REP")]
            RepPrefix,
        }
    }
}