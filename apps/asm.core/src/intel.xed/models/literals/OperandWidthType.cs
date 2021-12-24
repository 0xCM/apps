//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-width-enum.h/all-widths.txt
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
            INVALID,

            [Symbol("asz", "Varies with effective address width and may be one of 2, 4, 8")]
            ASZ,

            [Symbol("ssz", "Varies with stack address width and may be one of 2, 4, or 8")]
            SSZ,

            [Symbol("pseudo")]
            PSEUDO,

            [Symbol("pseudox87")]
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

            [Symbol("dq", "i32")]
            DQ,

            [Symbol("xub", "u8")]
            XUB,

            [Symbol("xuw", "u16")]
            XUW,

            [Symbol("xud", "u32")]
            XUD,

            [Symbol("xuq", "u64")]
            XUQ,

            [Symbol("x128", "u128")]
            X128,

            [Symbol("xb", "i8")]
            XB,

            [Symbol("xw", "i16")]
            XW,

            [Symbol("xd", "i32")]
            XD,

            [Symbol("xq", "i64")]
            XQ,

            ZB,

            ZW,

            ZD,

            ZQ,

            MB,

            MW,

            MD,

            MQ,

            M64INT,

            M64REAL,

            MEM108,

            MEM14,

            MEM16,

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

            V,

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

            BND32,

            BND64,

            PMMSZ16,

            PMMSZ32,

            QQ,

            YUB,

            YUW,

            YUD,

            YUQ,

            Y128,

            YB,

            YW,

            YD,

            YQ,

            YPS,

            YPD,

            ZBF16,

            VV,

            ZV,

            WRD,

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

            [Symbol("m384", "struct/48 bytes")]
            M384,

            [Symbol("m512", "struct/64 bytes")]
            M512,

            PTR,

            TMEMROW,

            TMEMCOL,

            TV,
        }
    }
}