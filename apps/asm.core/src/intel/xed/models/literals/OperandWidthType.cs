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
            INVALID,

            [Symbol("ASZ", "Varies with effective address width and may be one of [2 | 4 | 8]")]
            ASZ,

            [Symbol("SSZ", "Varies with stack address width and may be one of [2 | 4 | 8]")]
            SSZ,

            PSEUDO,

            PSEUDOX87,

            A16,

            A32,

            B,

            D,

            I8,

            U8,

            I16,

            U16,

            I32,

            U32,

            I64,

            U64,

            F16,

            F32,

            F64,

            DQ,

            XUB,

            XUW,

            XUD,

            XUQ,

            X128,

            XB,

            XW,

            XD,

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

            M384,

            M512,

            PTR,

            TMEMROW,

            TMEMCOL,

            TV,
        }
    }
}