//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-width-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// sources/xed/all-widths.txt
        /// </summary>
        [SymSource(xed)]
        public enum OperandWidthType : byte
        {
            None,

            [Symbol("asz", "Varies with effective address width and may be one of [2 | 4 | 8]")]
            ASZ,

            [Symbol("ssz", "Varies with stack address width and may be one of [2 | 4 | 8]")]
            SSZ,

            PSEUDO,

            PSEUDOX87,

            [Symbol("a16")]
            A16,

            [Symbol("a32")]
            A32,

            [Symbol("b")]
            B,

            [Symbol("d")]
            D,

            [Symbol("i8")]
            I8,

            [Symbol("u8")]
            U8,

            [Symbol("i16")]
            I16,

            [Symbol("u16")]
            U16,

            [Symbol("i32")]
            I32,

            [Symbol("u32")]
            U32,

            [Symbol("i64")]
            I64,

            [Symbol("u64")]
            U64,

            [Symbol("f16")]
            F16,

            [Symbol("f32")]
            F32,

            [Symbol("f64")]
            F64,

            [Symbol("dq")]
            DQ,

            XUB,

            XUW,

            [Symbol("xud")]
            XUD,

            [Symbol("xuq")]
            XUQ,

            X128,

            [Symbol("xb")]
            XB,

            [Symbol("xw")]
            XW,

            [Symbol("xd")]
            XD,

            XQ,

            [Symbol("zb")]
            ZB,

            [Symbol("zw")]
            ZW,

            [Symbol("zd")]
            ZD,

            [Symbol("zq")]
            ZQ,

            [Symbol("mb")]
            MB,

            [Symbol("mw")]
            MW,

            [Symbol("md")]
            MD,

            [Symbol("mq")]
            MQ,

            [Symbol("m64int")]
            M64INT,

            [Symbol("m64real")]
            M64REAL,

            [Symbol("mem108")]
            MEM108,

            [Symbol("mem14")]
            MEM14,

            [Symbol("mem16")]
            MEM16,

            [Symbol("mem16int")]
            MEM16INT,

            MEM28,

            MEM32INT,

            MEM32REAL,

            MEM80DEC,

            MEM80REAL,

            F80,

            MEM94,

            MFPXENV,

            MXSAVE,

            MPREFETCH,

            P,

            P2,

            PD,

            PS,

            PI,

            Q,

            S,

            S64,

            SD,

            SI,

            SS,

            [Symbol("v")]
            V,

            [Symbol("y")]
            Y,

            W,

            Z,

            SPW8,

            SPW,

            SPW5,

            SPW3,

            SPW2,

            I1,

            I2,

            I3,

            I4,

            I5,

            I6,

            I7,

            VAR,

            [Symbol("bnd32")]
            BND32,

            [Symbol("bnd64")]
            BND64,

            PMMSZ16,

            PMMSZ32,

            [Symbol("qq")]
            QQ,

            [Symbol("yub")]
            YUB,

            [Symbol("yuw")]
            YUW,

            [Symbol("yud")]
            YUD,

            [Symbol("yuq")]
            YUQ,

            [Symbol("y128")]
            Y128,

            [Symbol("yb")]
            YB,

            [Symbol("yw")]
            YW,

            [Symbol("yd")]
            YD,

            [Symbol("yq")]
            YQ,

            [Symbol("yps")]
            YPS,

            [Symbol("ypd")]
            YPD,

            ZBF16,

            VV,

            ZV,

            WRD,

            [Symbol("mskw")]
            MSKW,

            ZMSKW,

            ZF32,

            ZF64,

            ZUB,

            ZUW,

            ZUD,

            ZUQ,

            ZI8,

            ZI16,

            ZI32,

            ZI64,

            ZU8,

            ZU16,

            ZU32,

            ZU64,

            ZU128,

            M384,

            M512,

            PTR,

            TMEMROW,

            TMEMCOL,

            [Symbol("tv")]
            TV,
        }
    }
}